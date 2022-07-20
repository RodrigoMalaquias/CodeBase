namespace CodeBase.Borders.Exceptions
{
    using CodeBase.Shared.Models;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ConflictException : UseCaseException
    {
        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConflictException(ErrorMessage errorMessages) : base(errorMessages)
        {
        }

        public ConflictException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
