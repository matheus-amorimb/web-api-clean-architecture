using System.ComponentModel.DataAnnotations;

namespace CleanArch.Api.Models;

public record UserRegisterRequest(
    [property: EmailAddress, Required]
    string Email,
    [property: Required]
    string Password,
    [property: Required, Compare("Password")]
    string ConfirmPassword
);