using SX.Shared.Certificates.Models;
using SX.Shared.Exceptions;
using SX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.Pkcs;
using System.Linq;

namespace SX.Shared.Certificates.Services
{
    public class CryptoProService //: ICryptoProSignatureService, IDigitalSignatureValidator
    {
        public DigitalSignatureValidation VerifySignature(FileData data, FileData signature)
        {
            return this.VerifySignature(data, signature, out CertificateX509 cert);
        }

        public DigitalSignatureValidation VerifySignature(FileData data, FileData signature, out CertificateX509 certificate)
        {
            if (signature == null || data == null)
                throw new CustomArgumentException("Отсутствует файл подписи или файл данных.");

            //создаем контейнер с оригинальными данными, подпись которых будет проверяться
            var content = new ContentInfo(data);

            //формируем пакет с оригинальными данными и параметрами подписи
            var cms = new SignedCms(content, true);

            certificate = null;

            try
            {
                //декодируем файл, содержащий подпись
                cms.Decode(signature);

                //Проверяем что файл подписанн этой подписью 
                cms.CheckSignature(false);

                // получаем сертификат из CMS
                certificate = this.GetCertificateFromCSM(cms);
                if (certificate == null)
                    throw new CustomArgumentException("Не определен сертификат подписи!");

                // получаем время подписания
                var signingTime = CryptoProService.GetSigningTime(cms.SignerInfos[0]);

                return new DigitalSignatureValidation(new DigitalSignatureInfo
                {
                    Certificate = certificate,
                    SigningTime = signingTime
                });
            }
            catch (Exception ex)
            {
                return DigitalSignatureValidation.Error(ex.Message);
            }
        }

        public CertificateValidation VerifyCertificate(FileData certificateData)
        {
            if (certificateData == null)
                throw new CustomArgumentException("Не заданы данные сертификата для проверки!");

            try
            {
                // получаем сертификат из масива байт
                var cert = new CertificateX509(certificateData);
                if (cert == null)
                    throw new CustomArgumentException("Не определен сертификат для проверки!");

                // создаем проверятор сертификатов
                var certValidator = new CertificateValidator();

                // производим проверку и возвращаем результат
                return certValidator.Validate(cert, new CertificateValidationOptions()
                {
                    LogCorrectMessages = false
                });
            }
            catch (Exception ex)
            {
                return CertificateValidation.Error(ex.Message);
            }
        }

        //public byte[] HashData(byte[] data, string certSerialNumber)
        //{
        //    if (data == null || String.IsNullOrEmpty(certSerialNumber))
        //        throw new CustomArgumentException("Отсутствует файл для подписи или серийный номер сертификата");

        //    //получаем сертификаты из хранилища.
        //    var certificateX509 = this.GetCertificateFromStore(certSerialNumber);
        //    if (certificateX509 == null)
        //        throw new CustomNotFoundException("В хранилище не найден сертификат.");

        //    // имя олгоритма для хэширования
        //    var algorithmName = certificateX509.GetKeyAlgorithm();
        //    HashAlgorithm hashAlgorithm;

        //    if (algorithmName == "1.2.643.7.1.1.1.1")
        //    {
        //        //hashAlgorithm = "2012256";
        //        hashAlgorithm = new Gost3411_2012_256CryptoServiceProvider();
        //    }
        //    else if (algorithmName == "1.2.643.7.1.1.1.2")
        //    {
        //        //hashAlgorithm = "2012512";
        //        hashAlgorithm = new Gost3411_2012_512CryptoServiceProvider();
        //    }
        //    else if (algorithmName == "1.2.643.2.2.19")
        //    {
        //        //hashAlgorithm = "3411";
        //        hashAlgorithm = new Gost3411CryptoServiceProvider();
        //    }
        //    else
        //        throw new CustomNotImplementedException("Реализуемый алгоритм не подходит для подписания документа!");

        //    using (hashAlgorithm)
        //    {
        //        return hashAlgorithm.ComputeHash(data);
        //        //return String.Join(string.Empty, hashAlgorithm.ComputeHash(data).Select(x => x.ToString("X2")));
        //    }
        //}



        public byte[] SignData(byte[] data, string certSerialNumber)
        {
            if (data == null || String.IsNullOrEmpty(certSerialNumber))
                throw new CustomArgumentException("Отсутствует файл для подписи или серийный номер сертификата");

            //получаем сертификаты из хранилища.
            var certificateX509 = this.GetCertificateFromStore(certSerialNumber);
            if (certificateX509 == null)
                throw new CustomNotFoundException("В хранилище не найден сертификат.");

            //создаем контейнер с данными, которые будут подписываться
            var content = new ContentInfo(data);

            //создаем пакет, в который помещаем контейнер с данными и параметры подписи
            //это основной объект, в рамках которого формируются проверки и преобразования подписи
            var cms = new SignedCms(content, true);

            //создаем подписанта (объект на основе сертификата, который будет подписывать)
            var signer = new CmsSigner(certificateX509);

            //с помощью подписанта подписываем пакет так,
            //что теперь в пакете находятся не сами данные,
            //а именно подписанные данные, то есть:
            //  - сама подпись в случае отсоединенной подписи
            cms.ComputeSignature(signer, true);

            // возвращаем подпись в bytes формат base64.
            return Encoding.UTF8.GetBytes(Convert.ToBase64String(cms.Encode()));
        }


        //public byte[] SignHash(byte[] hash, string certSerialNumber)
        //{
        //    if (hash == null || String.IsNullOrEmpty(certSerialNumber))
        //        throw new CustomArgumentException("Отсутствует хэш-данные для подписи или серийный номер сертификата");

        //    //получаем сертификаты из хранилища.
        //    var certificateX509 = this.GetCertificateFromStore(certSerialNumber);
        //    if (certificateX509 == null)
        //        throw new CustomNotFoundException("В хранилище не найден сертификат.");


        //    CAdESCOM.CPHashedData hd = new CAdESCOM.CPHashedData();
        //    hd.Algorithm = 100;

        //    var gost = new Gost3410CryptoServiceProvider();
        //    gost.ContainerCertificate = certificateX509;
        //    return gost.SignHash(hash);
        //}


        private CertificateX509 GetCertificateFromCSM(SignedCms cms)
        {
            if (cms == null)
                return null;

            foreach (SignerInfo si in cms.SignerInfos)
                return new CertificateX509(si.Certificate);

            return null;
        }

        private X509Certificate2 GetCertificateFromStore(string certSerial)
        {
            //открываем хранилище сертификатов (личные сертификаты для текущего пользователя)
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            //открываем это хранилище для чтения
            store.Open(OpenFlags.ReadOnly);

            //фильтруем все доступные сертификаты
            return store.Certificates.Cast<X509Certificate2>()
                                    .Where(cert => cert.NotBefore < DateTime.Now
                                        && DateTime.Now < cert.NotAfter
                                        && cert.HasPrivateKey == true
                                        && cert.SerialNumber == certSerial)
                                    .FirstOrDefault();
        }

        public void Dispose() { }

        static private AsnEncodedData GetAttributeValueByOid(CryptographicAttributeObjectCollection attrCollection, string oid)
        {
            return attrCollection.Cast<CryptographicAttributeObject>()
                .FirstOrDefault(x => x.Oid.Value == oid)
                ?.Values[0];
        }

        static private DateTime? GetSigningTime(SignerInfo signerInfo)
        {
            var dateOID = "1.2.840.113549.1.9.5";

            return (((CryptoProService.GetAttributeValueByOid(signerInfo.SignedAttributes, dateOID)
                  ?? CryptoProService.GetAttributeValueByOid(signerInfo.UnsignedAttributes, dateOID))
                  as Pkcs9SigningTime)?.SigningTime)
                  ?.ToLocalTime();
        }

        static public DateTime? GetSigningTime(FileData data, FileData signature)
        {
            if (signature == null || data == null)
                throw new CustomArgumentException("Отсутствует файл подписи или файл данных для проверки даты подписания.");

            try
            {
                //создаем контейнер с оригинальными данными, подпись которых будет проверяться
                var content = new ContentInfo(data);

                //формируем пакет с оригинальными данными и параметрами подписи
                var cms = new SignedCms(content, true);

                //декодируем файл, содержащий подпись
                cms.Decode(signature);

                // получаем время подписания
                return CryptoProService.GetSigningTime(cms.SignerInfos[0]);
            }
            catch
            {
                return null;
            }
        }



        public ICollection<CertificateX509> GetCertificatesFromStore()
        {
            //открываем хранилище сертификатов (личные сертификаты для текущего пользователя)
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            //открываем это хранилище для чтения
            store.Open(OpenFlags.ReadOnly);

            //фильтруем все доступные сертификаты
            return store.Certificates.Cast<X509Certificate2>()
                                    .Where(cert => cert.NotBefore < DateTime.Now && DateTime.Now < cert.NotAfter)
                                    .Select(cert => new CertificateX509(cert))
                                    .ToArray();
        }

        public CertificateX509 GetCertificateFromFile(byte[] data, string password)
        {
            //проверяем, что данные не пусты
            if (data == null || data.Length <= 0)
                return null;

            //создаем новый сертификат из данных файла
            return new CertificateX509(new X509Certificate2(data, password));
        }

    }
}
