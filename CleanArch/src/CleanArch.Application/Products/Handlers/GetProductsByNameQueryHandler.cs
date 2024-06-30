using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class GetProductsByNameQueryHandler: IRequestHandler<GetProductByNameQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByName(request.Name);
    }
}