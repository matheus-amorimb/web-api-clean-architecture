using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id);
        if (existingProduct == null) throw new ApplicationException("Product not found");
        return await _productRepository.DeleteAsync(existingProduct);
    }
}