namespace CodeBase.Borders.Exceptions
{
    using CodeBase.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public class UseCaseException : Exception
    {
        public IEnumerable<ErrorMessage> ErrorMessages { get; set; }
        public UseCaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UseCaseException(IEnumerable<ErrorMessage> errorMessages) : base("An error has occured")
        {
            ErrorMessages = errorMessages;
        }

        public UseCaseException(ErrorMessage errorMessage) : base("An error has occured")
        {
            ErrorMessages = new[] { errorMessage };
        }

        public UseCaseException() : base("An error has occured")
        {
        }

        public UseCaseException(string errorMessage) : base("An error has occured")
        {
            ErrorMessages = new[] { new ErrorMessage(errorMessage) };
        }
    }
}
