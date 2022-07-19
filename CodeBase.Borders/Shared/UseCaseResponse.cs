namespace CodeBase.Borders.Shared
{
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class UseCaseResponse<T>
    {
        public UseCaseResponseKind Status { get; private set; }
        public IEnumerable<ErrorMessage> Errors { get; private set; }

        public T Result { get; private set; }

        public UseCaseResponse()
        {
            Status = UseCaseResponseKind.OK;
        }

        public bool Success()
        {
            return Errors is null;
        }

        public UseCaseResponse<T> SetResult(T result, object request = null, string message = "")
        {
            Result = result;
            Log.Information($"{message} \n  Request: {{@request}}.\n  Result: {{@result}}", request, result);
            return SetResult(UseCaseResponseKind.OK);
        }

        public UseCaseResponse<T> SetCreated(T result, object request = null, string message = "")
        {
            Result = result;
            Log.Information($"{message} \n  Request: {{@request}}.\n  Result: {{@result}}", request, result);
            return SetResult(UseCaseResponseKind.Created);
        }

        public UseCaseResponse<T> SetAccepted(T result, object request = null, string message = "")
        {
            Result = result;
            Log.Information($"{message} \n  Request: {{@request}}.\n  Result: {{@result}}", request, result);
            return SetResult(UseCaseResponseKind.Accepted);
        }

        public UseCaseResponse<T> SetBadRequest(IEnumerable<ErrorMessage> errors, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.BadRequest, errors, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetBadRequest(ErrorMessage error, object request = null, Exception exception = null, string message = "",
           [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.BadRequest, new[] { error }, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetNotFound(IEnumerable<ErrorMessage> errors, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.NotFound, errors, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetNotFound(ErrorMessage error, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.NotFound, new[] { error }, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetConflict(IEnumerable<ErrorMessage> errorMessages, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.Conflict, errorMessages, request, exception, sourceFilePath, memberName,
               sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetUnprocessableEntity(IEnumerable<ErrorMessage> errors, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.UnprocessableEntity, errors, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetUnprocessableEntity(ErrorMessage error, object request = null, Exception exception = null, string message = "",
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetWarning(UseCaseResponseKind.UnprocessableEntity, new[] { error }, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        private UseCaseResponse<T> SetError(UseCaseResponseKind status, IEnumerable<ErrorMessage> errors = null,
            object request = null, Exception exception = null, string sourceFilePath = "", string memberName = "", int sourceLineNumber = 0, string message = "")
        {
            Log.Error(exception, $"{message} \n  Request: {{@request}}.\n  Errors {{@errors}}\n  at {{@memberName}} in {{@sourceFilePath}} line {{@sourceLineNumber}}",
                request, errors, memberName, sourceFilePath, sourceLineNumber);
            return SetResult(status, errors);
        }

        public UseCaseResponse<T> SetInternalServerError(string message, IEnumerable<ErrorMessage> errors, object request = null, Exception exception = null,
            [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetError(UseCaseResponseKind.InternalServerError, errors, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetInternalServerError(string message, ErrorMessage error, object request = null, Exception exception = null,
        [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetError(UseCaseResponseKind.InternalServerError, new[] { error }, request, exception, sourceFilePath, memberName,
                sourceLineNumber, message);
        }

        public UseCaseResponse<T> SetBadGateway(ErrorMessage error, object request = null, Exception exception = null, string message = "",
           [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string memberName = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            return SetError(UseCaseResponseKind.BadGateway, new[] { error }, request, exception, memberName: memberName, message: message);
        }

        public UseCaseResponse<T> SetUnavailable(T result)
        {
            Result = result;
            Status = UseCaseResponseKind.Unavailable;
            Errors = new[] { BuilderErrorMessage.Build("Service Unavailable") };
            return this;
        }

        private UseCaseResponse<T> SetResult(UseCaseResponseKind status, IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            Errors = errors;
            return this;
        }

        private UseCaseResponse<T> SetWarning(UseCaseResponseKind status, IEnumerable<ErrorMessage> errors = null,
            object request = null, Exception exception = null, string sourceFilePath = "", string memberName = "", int sourceLineNumber = 0, string message = "")
        {
            Log.Warning(exception, $"{message} \n Request: {{@request}}.\n  Warnings {{@errors}}\n  at {{@memberName}} in {{@sourceFilePath}} line {{@sourceLineNumber}}",
                request, errors, memberName, sourceFilePath, sourceLineNumber);
            return SetResult(status, errors);
        }
    }
}
