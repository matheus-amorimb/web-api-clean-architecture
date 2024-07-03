using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    [Route("all")]
    public async Task<ActionResult> GetAll()
    {
        var categories = await _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var category = await _categoryService.GetById(id);
        return Ok(category);
    }

    [HttpPost]
    [Route("new")]
    public async Task<ActionResult> Create([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
    {
        var categoryValidator = new CreateCategoryRequestDtoValidator();
        var validation = await categoryValidator.ValidateAsync(createCategoryRequestDto);
        if(!validation.IsValid) validation.Errors.ForEach(Console.WriteLine);
        await _categoryService.Create(createCategoryRequestDto);
        return Ok(createCategoryRequestDto);
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult> Update(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        await _categoryService.Update(updateCategoryRequestDto);
        return Ok(updateCategoryRequestDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _categoryService.Delete(id);
        return Ok(id);
    }
    
}