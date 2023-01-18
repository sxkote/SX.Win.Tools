using System;
using System.Net;

namespace SX.Shared.Exceptions
{

    public class CustomException : ApplicationException
    {
        public virtual string Comment { get; protected set; }

        public virtual int StatusCode { get => (int)HttpStatusCode.InternalServerError; }

        public override string Message => this.Comment ?? "";

        public CustomException(string comment)
        {
            this.Comment = comment;
        }
    }

    public class CustomNotFoundException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.NotFound; }

        public CustomNotFoundException(string comment)
            : base(comment) { }
    }

    public class CustomExecutionException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.MethodNotAllowed; }

        public CustomExecutionException(string comment)
            : base(comment) { }
    }

    public class CustomOperationException : CustomExecutionException
    {
        public CustomOperationException(string comment)
            : base(comment) { }
    }

    public class CustomArgumentException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.BadRequest; }

        public CustomArgumentException(string comment)
            : base(comment) { }
    }

    public class CustomInputException : CustomArgumentException
    {
        public CustomInputException(string comment)
            : base(comment){}
    }

    public class CustomNotImplementedException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.NotImplemented; }

        public CustomNotImplementedException(string comment)
            : base(comment) { }
    }

    public class CustomFormatException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.MethodNotAllowed; }

        public CustomFormatException(string comment)
            : base(comment) { }
    }

    public class CustomAuthenticationException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.Unauthorized; }

        public CustomAuthenticationException(string comment)
            : base(comment) { }
    }

    public class CustomAccessException : CustomException
    {
        public override int StatusCode { get => (int)HttpStatusCode.Forbidden; }

        public CustomAccessException(string comment)
            : base(comment) { }
    }

}
