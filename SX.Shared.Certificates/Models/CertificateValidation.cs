using SX.Shared.Models;

namespace SX.Shared.Certificates.Models
{
    public class CertificateValidation : ValidationResult<CertificateX509>
    {
        public CertificateValidation(CertificateX509 data) : base(data) { }

        static public CertificateValidation Error(string message)
        {
            var result = new CertificateValidation(null);
            result.AddError(message);
            return result;
        }
    }
}
