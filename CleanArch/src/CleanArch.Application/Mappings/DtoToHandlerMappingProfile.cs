using AutoMapper;
using CleanArch.Application.DTOs.Requests;
using CleanArch.Application.DTOs.Responses;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;

namespace CleanArch.Application.Mappings;

public class DtoToHandlerMappingProfile : Profile
{
    public DtoToHandlerMappingProfile()
    {
        CreateMap<CreateProductRequestDto, ProductCreateCommand>().ReverseMap();
        CreateMap<CreateProductRequestDto, ProductUpdateCommand>().ReverseMap();
    }
}