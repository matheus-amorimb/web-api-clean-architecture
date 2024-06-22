using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set;}
    public string Description { get; private set;}
    public decimal Price { get; private set;}
    public int Stock { get; private set;}
    public string Image { get; private set;}
    public Guid CategoryId { get; set;}
    public Category? Category { get; set;}

    public Product(string? name, string? description, decimal price, int stock, string? image)
    {
        SetName(name!);
        SetDescription(description!);
        SetPrice(price);
        SetStock(stock);
        SetImage(image!);
    }
    public Product(Guid id, string? name, string? description, decimal price, int stock, string? image)
    {
        Id = id;
        SetName(name!);
        SetDescription(description!);
        SetPrice(price);
        SetStock(stock);
        SetImage(image!);
    }
    
    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new DomainException("Invalid name. Name cannot be empty.");
        if (name.Length < 3) throw new DomainException("Invalid name. Name must be at least 3 letter length");
        Name = name;
    }
    
    private void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description)) throw new DomainException("Invalid description. Description cannot be empty.");
        if (description.Length < 5) throw new DomainException("Invalid description. Description must be at least 5 letters length");

        Description = description;
    }

    private void SetPrice(decimal price)
    {
        if (price < 0.01m) throw new DomainException("Invalid description. Price must be greater than 0.01");
        Price = price;
    }

    private void SetStock(int stock)
    {
        if (stock <= 0) throw new DomainException("Invalid stock. Stock must be greater than 0");
        Stock = stock;
    }    
    private void SetImage(string image)
    {
        if (image.Length > 250) throw new DomainException("Invalid image. Image must have a maximum 250 characters");
        Image = image;
    }
    
}