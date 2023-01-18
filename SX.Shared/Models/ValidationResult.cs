using SX.Shared.Enums;
using System.Linq;

namespace SX.Shared.Models
{
    public class ValidationResult<T> : LogResult
    {
        public T Data { get; protected set; }

        public ValidationResult(T data)
            : base() { Data = data; }

        public bool IsCorrect() => !this.Messages.Any(m => m.Type == LogMessageType.Error);
    }
}
