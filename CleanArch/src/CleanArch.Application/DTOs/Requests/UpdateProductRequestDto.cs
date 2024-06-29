using CleanArch.Domain.Entities;

namespace CleanArch.Application.DTOs.Requests;

public record UpdateProductRequestDto(Guid Id, string Name, string Description, decimal Price, int Stock, string Image, Category Category, Guid CategoryId);