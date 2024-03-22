using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public sealed class ProductReadDbContext : DbContext
{
    public ProductReadDbContext(DbContextOptions<ProductReadDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductReadDbContext).Assembly);
        
        modelBuilder.Entity<Product>()
                    .Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");
    }



}