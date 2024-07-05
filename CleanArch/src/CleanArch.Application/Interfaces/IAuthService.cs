using CleanArch.Api.Models;

namespace CleanArch.Application.Interfaces;

public interface IAuthService
{
    Task<UserRegisterRequest> Signup(UserRegisterRequest userRegisterRequest);
    Task<UserLoginRequest> Login(UserLoginRequest userLoginRequest);
}