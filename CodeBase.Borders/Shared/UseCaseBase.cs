namespace CodeBase.Borders.Shared
{
    using CodeBase.Shared;
    using CodeBase.Shared.Extensions;
    using Exceptions;
    using FluentValidation;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class UseCaseBase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
    {
        public abstract string DefaultErrorMessage { get; }
        public abstract string DefaultSuccessMessage { get; }

        public async Task<UseCaseResponse<TResponse>> Execute(TRequest request)
        {
            UseCaseResponse<TResponse> useCaseResponse = new();

            try
            {
                SuccessResponse<TResponse> response = await ExecuteUseCaseAsync(request);

                switch (response.ResponseKind)
                {
                    case SuccessKind.Ok:
                        return useCaseResponse.SetResult(response.ResponseValue, request, DefaultSuccessMessage);
                    case SuccessKind.Created:
                        return useCaseResponse.SetCreated(response.ResponseValue, request, DefaultSuccessMessage);
                    case SuccessKind.Accepted:
                        return useCaseResponse.SetAccepted(response.ResponseValue, request, DefaultSuccessMessage);
                    default:
                        throw new NotImplementedException($"Kind [{response.ResponseKind}] not implemented.");
                }
            }
            catch (ValidationException e)
            {
                System.Collections.Generic.List<CodeBase.Shared.Models.ErrorMessage> errorsMessage = e.Errors.ToErrorMessages().ToList();

                if (errorsMessage.IsNullOrEmpty())
                    errorsMessage.Add(BuilderErrorMessage.Build(e.Message));

                return useCaseResponse.SetBadRequest(errorsMessage, request, e, DefaultErrorMessage);
            }
            catch (BadRequestException e)
            {
                return useCaseResponse.SetBadRequest(e.ErrorMessages, request, message: DefaultErrorMessage);
            }
            catch (ConflictException e)
            {
                return useCaseResponse.SetConflict(e.ErrorMessages, request, message: DefaultErrorMessage);
            }
            catch (NotFoundException e)
            {
                return useCaseResponse.SetNotFound(e.ErrorMessages, request, message: DefaultErrorMessage);
            }
            catch (InternalServerErrorException e)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, e.ErrorMessages, request);
            }
            catch (HttpRequestException e)
            {
                return useCaseResponse.SetBadGateway(BuilderErrorMessage.Build(DefaultErrorMessage), request, e, DefaultErrorMessage);
            }
            catch (Exception e)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, BuilderErrorMessage.Build(Messages.UnexpectedError), request, e);
            }
        }

        protected abstract Task<SuccessResponse<TResponse>> ExecuteUseCaseAsync(TRequest request);

        protected Task<SuccessResponse<TResponse>> OK(TResponse responseValue)
        {
            return Task.FromResult(new SuccessResponse<TResponse>(responseValue));
        }

        protected Task<SuccessResponse<TResponse>> Created(TResponse responseValue)
        {
            return Task.FromResult(new SuccessResponse<TResponse>(responseValue, SuccessKind.Created));
        }

        protected Task<SuccessResponse<TResponse>> Accepted(TResponse responseValue)
        {
            return Task.FromResult(new SuccessResponse<TResponse>(responseValue, SuccessKind.Accepted));
        }

        protected class SuccessResponse<T>
        {
            public SuccessResponse(T responseValue, SuccessKind responseKind = SuccessKind.Ok)
            {
                ResponseValue = responseValue;
                ResponseKind = responseKind;
            }

            public T ResponseValue { get; init; }
            public SuccessKind ResponseKind { get; init; }

        }

        protected enum SuccessKind
        {
            Ok,
            Created,
            Accepted
        }
    }
}
