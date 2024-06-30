using AutoMapper;
using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;
using CleanArch.Application.Extensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAll()
    {
        var productsQuery = new GetProductsQuery();
        var result = await _mediator.Send(productsQuery);
        return _mapper.Map<IEnumerable<ProductResponseDto>>(result);
    }

    public async Task<ProductResponseDto> GetById(Guid id)
    {
        var productQuery = new GetProductByIdQuery(id);
        var result = await _mediator.Send(productQuery);
        return _mapper.Map<ProductResponseDto>(result);
    }

    public async Task<ProductResponseDto> GetProductCategory(Guid id)
    {
        var productQuery = new GetProductByIdQuery(id);
        var result = await _mediator.Send(productQuery);
        return _mapper.Map<ProductResponseDto>(result);
    }

    public async Task Create(CreateProductRequestDto createProductRequestDto)
    {
        var normalizedName = createProductRequestDto.Name.NormalizeString();
        var productByNameQuery = new GetProductByNameQuery(normalizedName);
        var existingProduct = await _mediator.Send(productByNameQuery);
        if(existingProduct is not null) throw new ArgumentException("Product already exists.");
        var productDtoWithNormalizedName = createProductRequestDto with {Name = normalizedName}; 
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDtoWithNormalizedName);
        await _mediator.Send(productCreateCommand);
    }

    public async Task Update(UpdateProductRequestDto updateProductRequestDto)
    {
        var normalizedName = updateProductRequestDto.Name.NormalizeString();
        var productDtoWithNormalizedName = updateProductRequestDto with { Name = normalizedName }; 
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDtoWithNormalizedName);
        await _mediator.Send(productUpdateCommand);
    }

    public async Task Delete(Guid id)
    {
        var productQuery = new GetProductByIdQuery(id);
        var existingProduct = await _mediator.Send(productQuery);
        if (existingProduct is null) throw new ArgumentException("Product not found for this id.");
        var removeCommand = new ProductRemoveCommand(id);
        await _mediator.Send(removeCommand);
    }
}