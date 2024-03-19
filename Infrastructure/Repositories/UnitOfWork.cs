using Domain.Abstractions;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _context;
        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
        }
        
        public IProductRepository ProductRepository => new ProductRepository(_context);
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(true) > 0;
        }
    }
}
