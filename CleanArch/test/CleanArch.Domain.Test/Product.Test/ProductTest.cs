using CleanArch.Domain.Test.Utilities;
using CleanArch.Domain.Validations;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Test.Product.Test;

public class ProductTest
{
    [Fact]
    public void Create_ProductSuccessfully()
    {
        var productExpected = new
        {
            Name = "iPhone 15 Max Pro",
            Description = "Apple state of art smartphone",
            Price = 1299,
            Stock = 100,
            Image = "iphone15pro.png"
        };

        var product = new Entities.Product(productExpected.Name, productExpected.Description, productExpected.Price,
            productExpected.Stock, productExpected.Image);

        product.Should().BeEquivalentTo(productExpected, options => options.ExcludingMissingMembers());
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("ab")]
    public void Create_ProductWithInvalidName_ThrowsAnException(string name)
    {
        Action action = () => ProductBuilder.New().WithName(name).Build();
        action.Should().Throw<DomainException>();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abcd")]
    public void Create_ProductWithInvalidDescription_ThrowsAnException(string description)
    {
        Action action = () => ProductBuilder.New().WithDescription(description).Build();
        action.Should().Throw<DomainException>();
    }   
    
    [Theory]
    [InlineData(0)]
    [InlineData(0.005)]
    [InlineData(-1)]
    public void Create_ProductWithInvalidPrice_ThrowsAnException(decimal price)
    {
        Action action = () => ProductBuilder.New().WithPrice(price).Build();
        action.Should().Throw<DomainException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Create_ProductWithInvalidStock_ThrowsAnException(int stock)
    {
        Action action = () => ProductBuilder.New().WithStock(stock).Build();
        action.Should().Throw<DomainException>();
    }
}