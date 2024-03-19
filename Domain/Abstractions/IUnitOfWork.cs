namespace Domain.Abstractions;
public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
