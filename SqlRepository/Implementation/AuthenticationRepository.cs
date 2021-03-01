using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;

namespace SqlRepository.Implementation
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(
              UserManager<ApplicationUser> userManager,
              RoleManager<IdentityRole> roleManager,
              IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        public async Task<Response> Register(UserRegister userDetails)
        {
            var userExist = await _userManager.FindByNameAsync(userDetails.UserName);
            if (userExist != null)
                return new Response { Status = "Error", Message = " User Already Exist" };

            ApplicationUser user = new ApplicationUser
            {
                Email = userDetails.EmailId,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userDetails.UserName
            };

            var result = await _userManager.CreateAsync(user, userDetails.Password);
            if (!result.Succeeded)
                return new Response { Status = "Error", Message = "Failed to register new user" };

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { UserRoles.User });
            }

            return new Response { Status = "Success", Message = "User Created Successfully" };
        }


        public async Task<Response> AdminRegister(UserRegister userDetails)
        {
            var userExist = await _userManager.FindByNameAsync(userDetails.UserName);
            if (userExist != null)
                return new Response { Status = "Error", Message = " User Already Exist" };

            ApplicationUser user = new ApplicationUser
            {
                Email = userDetails.EmailId,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userDetails.UserName
            };

            var result = await _userManager.CreateAsync(user, userDetails.Password);
            if (!result.Succeeded)
                return new Response { Status = $"{result.Errors.ToList()[0].Code}", Message = $"{result.Errors.ToList()[0].Description}" };

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { UserRoles.Admin });
            }

            return new Response { Status = "Success", Message = "User Created Successfully" };
        }


        public async Task<Response> Login(UserLogin userLoginDetails) 
        {
            var user = await _userManager.FindByNameAsync(userLoginDetails.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDetails.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSiginKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSiginKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new Response
                {
                    Message = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            return new Response { Message = "Unauthorized User." };
        }


    }
}
