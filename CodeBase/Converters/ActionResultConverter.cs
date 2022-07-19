namespace CodeBase.Converters
{
    using Borders.Shared;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using System.Linq;

    public class ActionResultConverter : IActionResultConverter
    {
        private readonly string _path;

        public ActionResultConverter(IHttpContextAccessor accessor)
        {
            _path = accessor.HttpContext.Request.Path.Value;
        }

        public IActionResult Convert<T>(UseCaseResponse<T> response, bool withContentOnSuccess = true)
        {
            if (response == null)
                return BuildResult(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

            if (response.Success())
            {
                if (withContentOnSuccess)
                    return BuildResult(response.Result, response.Status);

                return new NoContentResult();
            }

            if (response.Errors != null && response.Errors.Any())
            {
                return BuildResult(response.Errors, response.Status);
            }

            if (response.Result != null)
            {
                return BuildResult(response.Result, response.Status);
            }

            var hasNoErrors = response.Errors == null || !response.Errors.Any();
            var errorResult = hasNoErrors
                ? new[] { new ErrorMessage("000", "Unknown error") }
                : response.Errors;

            return BuildResult(errorResult, response.Status);
        }

        private ObjectResult BuildResult(object data, UseCaseResponseKind statusCode)
        {
            if (statusCode == UseCaseResponseKind.InternalServerError)
                Log.Error($"[ERROR] {_path} ({{@data}})", data);

            return new ObjectResult(data)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
