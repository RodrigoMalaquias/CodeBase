namespace CodeBase.Borders.Exceptions
{
    using CodeBase.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

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
