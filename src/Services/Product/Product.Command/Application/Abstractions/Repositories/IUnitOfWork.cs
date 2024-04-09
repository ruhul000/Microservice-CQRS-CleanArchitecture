namespace Application.Abstractions.Repositories;
public interface IUnitOfWork
{
    IProductCommandRepository ProductCommandRepository { get; }
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
