namespace CodeBase.Borders.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Shared;

    [Serializable]
    public class NotFoundException : UseCaseException
    {
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(IEnumerable<ErrorMessage> errorMessages) : base(errorMessages)
        {
        }

        public NotFoundException(ErrorMessage errorMessage) : base(errorMessage)
        {
        }

        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
