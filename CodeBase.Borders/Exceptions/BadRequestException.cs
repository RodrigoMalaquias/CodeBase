namespace CodeBase.Borders.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Shared;

    [Serializable]
    public class BadRequestException : UseCaseException
    {
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadRequestException(IEnumerable<ErrorMessage> errorMessages) : base(errorMessages)
        {
        }

        public BadRequestException(ErrorMessage errorMessage) : base(errorMessage)
        {
        }

        public BadRequestException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
