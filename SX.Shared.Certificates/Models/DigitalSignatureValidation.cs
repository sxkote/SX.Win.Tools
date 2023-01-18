using SX.Shared.Models;
using System;

namespace SX.Shared.Certificates.Models
{
    public class DigitalSignatureValidation : ValidationResult<DigitalSignatureInfo>
    {
        public DigitalSignatureValidation(DigitalSignatureInfo data) : base(data) { }

        static public DigitalSignatureValidation Error(string message)
        {
            var result = new DigitalSignatureValidation(new DigitalSignatureInfo()
            {
                Certificate = null,
                SigningTime = null
            });
            result.AddError(message);
            return result;
        }
    }
}
