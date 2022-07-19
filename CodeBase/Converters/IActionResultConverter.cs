namespace CodeBase.Converters
{
    using Borders.Shared;
    using Microsoft.AspNetCore.Mvc;

    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool withContentOnSuccess = true);
    }
}
