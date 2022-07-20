namespace CodeBase.Shared
{
    using Models;
    using System.Linq;

    public static class BuilderErrorMessage
    {
        public static ErrorMessage Build(string message)
        {
            System.Collections.Generic.List<string> structureMessage = message.Split('|').ToList();

            if (structureMessage.Count < 2)
                structureMessage.Insert(0, "000");

            string errorCode = structureMessage[0].Trim();
            string errorMessage = structureMessage[1].Trim();

            return new ErrorMessage
            {
                Code = errorCode,
                Message = errorMessage
            };
        }
    }
}
