using CleanArch.Application.DTOs.Requests;
using FluentValidation;

namespace CleanArch.Application.Validators;

public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateCategoryRequestDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}