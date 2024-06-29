using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;

namespace CleanArch.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetCategories();
    Task<CategoryResponseDto> GetById(Guid id);
    Task Create(CreateCategoryRequestDto createCategoryRequestDto);
    Task Update(UpdateCategoryRequestDto updateCategoryRequestDto);
    Task Delete(Guid id);
}