using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public sealed class ProductWriteDbContext : DbContext
{
    public ProductWriteDbContext(DbContextOptions<ProductWriteDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductWriteDbContext).Assembly);
        
        modelBuilder.Entity<Product>()
                    .Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");
    }



}