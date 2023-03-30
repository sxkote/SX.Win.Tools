using SX.Shared.Certificates.Contracts;
using SX.Shared.Certificates.Models;
using SX.Shared.Exceptions;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SX.Shared.Certificates.Services
{

    public class CertificateValidator : ICertificateValidator
    {
        public virtual CertificateValidation Validate(CertificateX509 certificate, CertificateValidationOptions options)
        {
            if (certificate == null)
                throw new CustomArgumentException("Не задан сертификат для проверки!");

            var validation = new CertificateValidation(certificate);

            Action<bool, string, string> addLog = (correct, name, value) =>
            {
                if (options.LogCorrectMessages || !correct)
                    validation.Add(correct ? Enums.LogMessageType.Info : Enums.LogMessageType.Error, $"{name}: {value}");
            };

            var now = Helpers.GetDateTime();

            // базовая проверка сертификата встроенной в .net функцией
            if (options.ValidateDefault)
            {
                bool isVerified = certificate.X509.Verify();
                addLog(isVerified, $"Базовая проверка", isVerified ? "сертификат действителен и не отозван (прошел стандартную проверку)" : "сертификат НЕ валиден (НЕ прошел стандартную проверку)");

                X509Chain chain = new X509Chain();

                try
                {
                    var chainBuilt = chain.Build(certificate.X509);
                    addLog(false, "Chain", string.Format("Chain building status: {0}", chainBuilt));

                    if (chainBuilt == false)
                        foreach (X509ChainStatus chainStatus in chain.ChainStatus)
                            addLog(false, "ChainDetail", string.Format("Chain error: {0} {1}", chainStatus.Status, chainStatus.StatusInformation));
                }
                catch (Exception ex)
                {
                    addLog(false, "ERROR", ex.ToString());
                }
            }

            // проверка периода действия сертификата
            if (options.ValidatePeriod)
            {
                bool isValid = certificate.NotBefore < now && now < certificate.NotAfter;
                addLog(isValid, $"Срок действия", String.Format("Срок действия: {0} ({1} - {2})", isValid ? "действителен" : "истек", certificate.NotBefore.ToShortDateString(), certificate.NotAfter.ToShortDateString()));
            }

            // проверка цепочки сертификатов
            if (options.ValidateChain)
            {
                //создаем цепочку сертификата
                X509Chain ch = new X509Chain();
                //отозванность сертификата хотим получать онлайн
                ch.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                //хотим проверить всю цепочку сертификатов
                ch.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                //проверка валидности самая полная 
                ch.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
                //строим цепочку на основе сертификата
                ch.Build(certificate.X509);

                bool isValid = true;
                foreach (X509ChainElement element in ch.ChainElements)
                {
                    // валидность конкретного сертификата
                    bool verify = element.Certificate.Verify();

                    // валидность всей цепочки
                    isValid = isValid && verify;

                    // результат проверки конкретного сертификата
                    addLog(verify, $"Валидность сертификата [{element.Certificate.Thumbprint}] в цепочке", verify.ToString());
                }

                // результат проверки цепочки
                addLog(isValid, $"Цепочка сертификата", isValid ? "Сертификат прошел проверку" : "Сертификат НЕ прошел проверку");
            }

            // проверка квалифицированности сертификата
            if (options.ValidateQualified)
            {

                bool isIP = !String.IsNullOrEmpty(certificate.OGRN) && certificate.OGRN.Length == 15;
                bool isQualified = true;

                string subjectCommonName = certificate.SubjectCommonName;
                string inn = certificate.INN.Trim();

                if (subjectCommonName == "")
                {
                    validation.AddError($"Не задано наименование (CN) Субъекта");
                    isQualified = false;
                }

                if (!isIP && certificate.Organization == "")
                {
                    validation.AddError($"Не задана организация (O) Субъекта");
                    isQualified = false;
                }

                if (!isIP && certificate.Locality == "")
                {
                    validation.AddError($"Не задана расположение (L) Субъекта");
                    isQualified = false;
                }

                //if (certificate.Email == "")
                //{
                //    result.AddError($"Не задан e-mail (E) Субъекта");
                //    isQualified = false;
                //}

                if (inn.Length != 10 && inn.Length != 12)
                {
                    validation.AddError($"ИНН Субъекта должен состоять из 10 или 12 знаков");
                    isQualified = false;
                }

                if (String.IsNullOrEmpty(certificate.OGRN))
                {
                    validation.AddError($"[{certificate.Thumbprint}] Не задан ОГРН Субъекта");
                    isQualified = false;
                }

                int CN_fio = 0;
                int CN_org = 0;

                string[] splits = subjectCommonName.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (splits.Length == 3)
                {
                    CN_fio += 3;

                    if (splits[2].EndsWith("вич") || splits[2].EndsWith("вна"))
                        CN_fio += 1;
                }
                else CN_org += 2;

                if (subjectCommonName.Contains("\""))
                    CN_org += 3;
                else CN_fio += 1;

                if (subjectCommonName.ToLower().Contains("ооо") || subjectCommonName.ToLower().Contains("зао") || subjectCommonName.ToLower().Contains("оао") || subjectCommonName.ToLower().Contains("пао") || subjectCommonName.ToLower().StartsWith("ип"))
                    CN_org += 2;

                if (CN_fio > CN_org && String.IsNullOrEmpty(certificate.SNILS))
                {
                    validation.AddError($"Не задан СНИЛС Субъекта");
                    isQualified = false;
                }

                addLog(isQualified, $"Проверка квалифицированного сертификата", isQualified ? "Сертификат является Квалифицированным" : "Сертификат НЕ является Квалифицированным");
            }

            return validation;
        }
    }
}
