namespace CodeBase.Borders.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Shared;

    [Serializable]
    public class InternalServerErrorException : UseCaseException
    {
        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InternalServerErrorException(IEnumerable<ErrorMessage> errorMessages) : base(errorMessages)
        {
        }

        public InternalServerErrorException(ErrorMessage errorMessage) : base(errorMessage)
        {
        }

        public InternalServerErrorException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
