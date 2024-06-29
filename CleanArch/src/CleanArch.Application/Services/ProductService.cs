using AutoMapper;
using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;
using CleanArch.Application.Extensions;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        Console.WriteLine(products.First());
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }

    public async Task<ProductResponseDto> GetById(Guid id)
    {
        var products = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductResponseDto>(products);
    }

    public async Task<ProductResponseDto> GetProductCategory(Guid id)
    {
        var product = await _productRepository.GetProductWithCategoryAsync(id);
        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task Create(CreateProductRequestDto createProductRequestDto)
    {
        var normalizedName = createProductRequestDto.Name.NormalizeString();
        var existingCategory = await _productRepository.GetByName(normalizedName);
        if(existingCategory is not null) throw new ArgumentException("Category already exists.");
        var productDtoWithNormalizedName = createProductRequestDto with {Name = normalizedName}; 
        var product = _mapper.Map<Product>(productDtoWithNormalizedName);
        await _productRepository.CreateAsync(product);
    }

    public async Task Update(UpdateProductRequestDto updateProductRequestDto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(updateProductRequestDto.Id);
        if(existingProduct is not null) throw new ArgumentException("Product not found for this id.");
        var normalizedName = updateProductRequestDto.Name.NormalizeString();
        var categoryDtoWithNormalizedName = updateProductRequestDto with { Name = normalizedName }; 
        var category = _mapper.Map<Product>(categoryDtoWithNormalizedName);
        await _productRepository.UpdateAsync(category);
    }

    public async Task Delete(Guid id)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct is null) throw new ArgumentException("Product not found for this id.");
        await _productRepository.DeleteAsync(existingProduct);
    }
}