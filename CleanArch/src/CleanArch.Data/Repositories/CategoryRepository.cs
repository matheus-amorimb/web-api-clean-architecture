using CleanArch.Data.Context;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Category?> GetByName(string name)
    {
        return await Context.Category.FirstOrDefaultAsync(category => category.Name == name);
    }
}