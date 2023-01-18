using System;

namespace SX.Shared.Certificates.Models
{
    public class DigitalSignatureInfo
    {
        public CertificateX509? Certificate { get; set; }
        public DateTime? SigningTime { get; set; }
    }
}
