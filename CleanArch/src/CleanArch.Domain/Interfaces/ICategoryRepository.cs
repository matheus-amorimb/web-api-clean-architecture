using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByName(string name);
}