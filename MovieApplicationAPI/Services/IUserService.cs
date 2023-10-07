using MovieAppAPI.Dto;
using MovieAppDomain;

namespace MovieAppAPI.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<User> LoginUserAsync(LoginDto loginDto);
    }
}
