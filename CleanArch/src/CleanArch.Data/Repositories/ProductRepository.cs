using CleanArch.Data.Context;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    { }

    public async Task<Product?> GetProductWithCategoryAsync(Guid productId)
    {
        var product = await Context.Product
            .Include(product => product.Category)
            .SingleOrDefaultAsync(product => product.Id == productId);

        return product;
    }

    public async Task<Product?> GetByName(string name)
    {
        return await Context.Product.FirstOrDefaultAsync(product => product.Name == name);
    }
}