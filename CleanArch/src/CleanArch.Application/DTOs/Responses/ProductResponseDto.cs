using CleanArch.Domain.Entities;

namespace CleanArch.Application.DTOs.Responses;

public record ProductResponseDto(Guid Id, string Name, string Description, decimal Price, int Stock, string Image, Category Category, Guid CategoryId);