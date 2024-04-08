namespace Domain.Abstractions;
public interface IUnitOfWork
{
    IProductCommandRepository ProductCommandRepository { get; }
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
