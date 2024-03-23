using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class AuthController : ControllerBase
    {

            private readonly UserManager<IdentityUser> userManager;
            private readonly ITokenRepository tokenRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository,
            IHttpContextAccessor  httpContextAccessor)

        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            httpContextAccessor = httpContextAccessor;
        }
        



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userName = $"{registerDto.Firstname}_{registerDto.Lastname}";

            var identityUser = new IdentityUser
            {
                UserName = userName,
                Email = registerDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);
            if (identityResult.Succeeded)
            {
                //Add roles to the user
                if (registerDto.Roles != null && registerDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("Registration Successful! Proceed to Login");
                    }
                }
            }
            var errors = identityResult.Errors.Select(e => e.Description);
            return BadRequest($"Failed to register user: {string.Join(", ", errors)}");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPassword)
                {
                    //Get User Roles
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var userId = user.Id;
                        var userName = user.UserName;
                        var userEmail = user.Email;

                        return Ok(new
                        {
                            JwtToken = jwtToken,
                            Id = userId,
                            Username = userName,
                            Email = userEmail
                        });
                        

                    }
                }
            }

            return BadRequest("Username or Password is incorrect");
        }

    }
}
