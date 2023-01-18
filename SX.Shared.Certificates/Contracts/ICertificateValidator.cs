using SX.Shared.Certificates.Models;

namespace SX.Shared.Certificates.Contracts
{
    public interface ICertificateValidator
    {
        CertificateValidation Validate(CertificateX509 certificate, CertificateValidationOptions options);
    }
}
