using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs.Responses;

public record CategoryResponseDto(Guid Id, string Name);