using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public sealed class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);

    public DbSet<Product> Products { get; set; }

}