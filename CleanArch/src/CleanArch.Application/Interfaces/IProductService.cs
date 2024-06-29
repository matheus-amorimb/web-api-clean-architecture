using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;

namespace CleanArch.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAll();
    Task<ProductResponseDto> GetById(Guid id);
    Task<ProductResponseDto> GetProductCategory(Guid id);
    Task Create(CreateProductRequestDto createProductRequestDto);
    Task Update(UpdateProductRequestDto updateProductRequestDto);
    Task Delete(Guid id);
}