namespace CodeBase.Borders.Shared
{
    using System.Threading.Tasks;

    public interface IUseCase<in TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }
}
