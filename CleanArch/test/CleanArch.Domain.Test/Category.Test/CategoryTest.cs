using CleanArch.Domain.Validations;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Test.Category.Test;

public class CategoryTest
{
    [Fact]
    public void Create_CategorySuccessfully()
    {
        var categoryExpected = new
        {
            Id = Guid.NewGuid(),
            Name = "Electronics"
        };

        var category = new Entities.Category(categoryExpected.Id, categoryExpected.Name);

        category.Should().BeEquivalentTo(categoryExpected, options => options.ExcludingMissingMembers());
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("ab")]
    public void Create_CategoryWithInvalidName_ThrowsAnException(string name)
    {
        Action action = () => new Entities.Category(Guid.NewGuid(), name);
        action.Should().Throw<DomainException>();
    }
    
}