namespace CodeBase.Borders.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Shared;

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
