using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; set; }
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }

}