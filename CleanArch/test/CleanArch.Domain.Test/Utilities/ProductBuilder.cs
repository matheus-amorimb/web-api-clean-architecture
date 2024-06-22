namespace CleanArch.Domain.Test.Utilities;

public class ProductBuilder
{
    private string _name;
    private string _description;
    private decimal _price;
    private int _stock;
    private string _image;
    private Guid _categoryId;
    private Entities.Category? _category;
    private ProductBuilder()
    { }
    
    public static ProductBuilder New()
    {
        return new ProductBuilder();
    }

    public ProductBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public ProductBuilder WithDescription(string name)
    {
        _name = name;
        return this;
    }

    public ProductBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }
    
    public ProductBuilder WithStock(int stock)
    {
        _stock = stock;
        return this;
    }

    public Entities.Product Build()
    {
        return new Entities.Product(Guid.NewGuid(), _name, _description, _price, _stock, _image);
    }
    
    
}