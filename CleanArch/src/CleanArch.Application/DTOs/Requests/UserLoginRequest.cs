using System.ComponentModel.DataAnnotations;

namespace CleanArch.Api.Models;

public record UserLoginRequest(
    [property: Required]
    string Email, 
    [property: Required]
    string Password
);