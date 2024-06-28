using System.Data;
using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities;

public sealed class Category : Entity
{
    public string? Name { get; private set;}
    public ICollection<Product> Products { get; } = new List<Product>();

    public Category(string name)
    {
        SetName(name);
    }    
    
    public Category(Guid id, string name)
    {
        Id = id;
        SetName(name);
    }

    public void Update(string name)
    {
        SetName(name);
    }
    
    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new DomainException("Invalid name. Name cannot be empty.");
        if (name.Length < 3) throw new DomainException("Invalid name. Name must be at least 3 letter length");

        Name = name;
    }
    
}