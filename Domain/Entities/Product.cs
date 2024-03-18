using Domain.Primitives;
using System;

namespace Domain.Entities;

public sealed class Product : Entity
{
    public Product(Guid id, string name, string description, double price) 
        : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
    }
    private Product() 
    { 
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
}
