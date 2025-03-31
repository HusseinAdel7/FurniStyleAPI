using Microsoft.AspNetCore.Identity;
using FurniStyle.Core.DTOs.Authentications;
using FurniStyle.Core.Entities.Identity;
using FurniStyle.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurniStyle.Core.IServices.Toekn;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FurniStyle.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return null;
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded) return null;
            return new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)
            };
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            if (await CheckEmailExistAsync(registerDTO.Email)) return null;
            var user = new ApplicationUser()
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email.Split("@")[0]
            };
            var registedUser = await _userManager.CreateAsync(user,registerDTO.Password);
            if (!registedUser.Succeeded) return null;
            return new UserDTO() 
            {
                DisplayName =user.DisplayName,
                Email= user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)

            };
        }
    
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }

       
    }
}
