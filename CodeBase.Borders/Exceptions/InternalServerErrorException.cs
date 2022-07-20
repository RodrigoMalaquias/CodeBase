namespace CodeBase.Borders.Exceptions
{
    using CodeBase.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

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
