namespace Kr.Backoffice.Domain.Models.Handler;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IRequest {}

public interface IRequest<out TResponse>{} 

