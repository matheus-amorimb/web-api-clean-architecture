using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("products")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productService.GetAll());
    }    
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GeById(Guid id)
    {
        return Ok(await _productService.GetById(id));
    }
    
    [HttpGet]
    [Route("category/{id:guid}")]
    public async Task<IActionResult> GeByIdWithCategory(Guid id)
    {
        return Ok(await _productService.GetProductCategory(id));
    }
    

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequestDto createProductRequestDto)
    {
        var validator = new CreateProductRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(createProductRequestDto);
        if(!validationResult.IsValid) validationResult.Errors.ForEach(Console.WriteLine); 
        await _productService.Create(createProductRequestDto);
        return Ok(createProductRequestDto);
    }
    
}