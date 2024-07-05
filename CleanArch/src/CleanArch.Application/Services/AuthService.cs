using CleanArch.Api.Models;
using CleanArch.Application.Interfaces;

namespace CleanArch.Application.Services;

public class AuthService : IAuthService
{
    public Task<UserRegisterRequest> Signup(UserRegisterRequest userRegisterRequest)
    {
        throw new NotImplementedException();
    }

    public Task<UserLoginRequest> Login(UserLoginRequest userLoginRequest)
    {
        throw new NotImplementedException();
    }
}