using AlumniPortal.Shared;
using AlumniPortal.Shared.Models;
using AlumniPortal.Shared.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.API.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResponseModel> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return new ResponseModel
                {
                    Message = "User not found",
                    IsSuccess = false
                };
            }

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
            {
                return new ResponseModel
                {
                    Message = "Invalid Password",
                    IsSuccess = false
                };
            }

            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier,user.Id),
             new Claim("Email",model.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new ResponseModel
            {
                Message = tokenString,
                IsSuccess = true,
                ExpireDate=token.ValidTo
            };
        }


        public async Task<ResponseModel> RegisterUserAsync(RegisterModel model)
        {
            if (model is null)
                throw new NullReferenceException("Model is empty");

            if (model.Password != model.ConfirmPassword)
            {
                return new ResponseModel
                {
                    Message = "Password does not match",
                    IsSuccess = false
                };
            }

            var user = new IdentityUser
            {
                Email = model.EmailAddress,
                UserName = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new ResponseModel
                {
                    Message = "User is not created",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            else
            {
                return new ResponseModel
                {
                    Message = "User created successfully",
                    IsSuccess = true,
                };
            }
        }
    }
}
