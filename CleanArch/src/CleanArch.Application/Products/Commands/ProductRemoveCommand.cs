using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands;

public class ProductRemoveCommand : IRequest<Product>
{
    public Guid Id { get; set; }

    public ProductRemoveCommand(Guid id)
    {
        Id = id;
    }
}