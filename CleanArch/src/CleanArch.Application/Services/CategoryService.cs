using AutoMapper;
using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;
using CleanArch.Application.Extensions;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAll()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }

    public async Task<CategoryResponseDto> GetById(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task Create(CreateCategoryRequestDto createCategoryRequestDto)
    {
        var normalizedName = createCategoryRequestDto.Name.NormalizeString();
        var existingCategory = await _categoryRepository.GetByName(normalizedName);
        if(existingCategory is not null) throw new ArgumentException("Category already exists.");
        var categoryDtoWithNormalizedName = new CreateCategoryRequestDto(Name: normalizedName); 
        var category = new Category(Guid.NewGuid(), categoryDtoWithNormalizedName.Name);
        await _categoryRepository.CreateAsync(category);
    }

    public async Task Update(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(updateCategoryRequestDto.Id);
        if(existingCategory is null) throw new ArgumentException("Category not found for this id.");
        var normalizedName = updateCategoryRequestDto.Name.NormalizeString();
        var categoryDtoWithNormalizedName = updateCategoryRequestDto with {Name = normalizedName}; 
        existingCategory = _mapper.Map<Category>(categoryDtoWithNormalizedName);
        await _categoryRepository.UpdateAsync(existingCategory);
    }

    public async Task Delete(Guid id)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(id);
        if (existingCategory is null) throw new ArgumentException("Category not found for this id.");
        await _categoryRepository.DeleteAsync(existingCategory);
    }
}