namespace CodeBase.Borders.Shared
{
    public enum UseCaseResponseKind
    {
        Processing = 102,
        OK = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        UnprocessableEntity = 422,
        InternalServerError = 500,
        BadGateway = 502,
        Unavailable = 503
    }
}
