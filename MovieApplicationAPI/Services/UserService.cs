using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieAppAPI.Data;
using MovieAppAPI.Dto;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;
using System.Security.Claims;
using System.Text;

namespace MovieAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            await _unitOfWork.UserRepo.RegisterUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<User> LoginUserAsync(LoginDto loginDto)
        {
            var user=_mapper.Map<User>(loginDto);  
            var founduser=  await _unitOfWork.UserRepo.LoginUserAsync(user);
            return founduser;
            
            
        }
    }
}
