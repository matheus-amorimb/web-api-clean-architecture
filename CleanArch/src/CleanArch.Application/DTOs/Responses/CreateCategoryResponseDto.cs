using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs.Responses;

public record CreateCategoryResponseDto(Guid Id, string Name);