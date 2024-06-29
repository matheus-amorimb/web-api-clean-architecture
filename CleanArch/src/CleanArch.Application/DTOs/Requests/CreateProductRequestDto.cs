using CleanArch.Domain.Entities;

namespace CleanArch.Application.DTOs.Requests;

public record CreateProductRequestDto(string Name, string Description, decimal Price, int Stock, string Image, Guid CategoryId);