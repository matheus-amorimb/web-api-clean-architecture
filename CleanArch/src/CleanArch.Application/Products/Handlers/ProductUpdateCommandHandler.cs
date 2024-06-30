using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id);
        if (existingProduct == null) throw new ApplicationException("Product not found");
        existingProduct.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
        return await _productRepository.UpdateAsync(existingProduct);
    }
}