using MediatR;

namespace Application.Abstractions.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
//public interface IQueryHandler<in TQuery, TResponse>
//    where TQuery : IQuery<TResponse>
//{
//    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
//}