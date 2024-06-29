using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetProductWithCategoryAsync(Guid productId);
    Task<Product> GetByName(string name);
}