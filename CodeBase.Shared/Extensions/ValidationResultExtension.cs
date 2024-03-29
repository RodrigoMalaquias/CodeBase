﻿namespace CodeBase.Shared.Extensions
{
    using FluentValidation.Results;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class ValidationResultExtension
    {
        public static IEnumerable<ErrorMessage> ToErrorMessages(this ValidationResult validationResult) =>
            validationResult.Errors.ToErrorMessages();

        public static IEnumerable<ErrorMessage> ToErrorMessages(this IEnumerable<ValidationFailure> validationFailures) =>
            validationFailures.Select(validationFailure => validationFailure.ToErrorMessage());

        private static ErrorMessage ToErrorMessage(this ValidationFailure validationFailure) =>
            BuilderErrorMessage.Build(validationFailure.ErrorMessage);
    }
}
