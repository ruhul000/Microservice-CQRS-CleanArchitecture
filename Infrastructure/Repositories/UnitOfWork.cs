using Domain.Abstractions;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductWriteDbContext _writeContext;

        public UnitOfWork(ProductWriteDbContext writeContext)
        {
            _writeContext = writeContext;
        }
        
        public IProductCommandRepository ProductCommandRepository => new ProductCommandRepository(_writeContext);
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _writeContext.SaveChangesAsync(true) > 0;
        }
    }
}
