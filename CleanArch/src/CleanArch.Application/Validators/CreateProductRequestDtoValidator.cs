using CleanArch.Application.DTOs.Requests;
using FluentValidation;

namespace CleanArch.Application.Validators;

public class CreateProductRequestDtoValidator : AbstractValidator<CreateProductRequestDto>
{
    public CreateProductRequestDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(3, 300).WithMessage("Length must be between 3 and 300");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");
        
        RuleFor(dto => dto.Price)
            .NotEmpty().WithMessage("Description is required.");
        
        RuleFor(dto => dto.Stock)
            .NotEmpty().WithMessage("Description is required.")
            .GreaterThan(1).WithMessage("Stock must be greater than 1.");
    }
}