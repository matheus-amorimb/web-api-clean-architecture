using AutoMapper;
using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
        CreateMap<Category, CreateCategoryResponseDto>();
        CreateMap<Product, CreateProductRequestDto>().ReverseMap();
        CreateMap<Product, CreateProductResponseDto>().ReverseMap();
    }
}