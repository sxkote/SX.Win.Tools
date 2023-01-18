namespace SX.Shared.Certificates.Models
{
    public class CertificateValidationOptions
    {
        public bool LogCorrectMessages { get; set; } = false;
        public bool ValidateDefault { get; set; } = true;
        public bool ValidatePeriod { get; set; } = true;
        public bool ValidateChain { get; set; } = true;
        public bool ValidateQualified { get; set; } = true;
    }
}
