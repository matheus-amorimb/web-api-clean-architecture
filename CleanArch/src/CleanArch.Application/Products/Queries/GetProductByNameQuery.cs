using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries;

public class GetProductByNameQuery : IRequest<Product>
{
    public string Name;

    public GetProductByNameQuery(string name)
    {
        Name = name;
    }
}