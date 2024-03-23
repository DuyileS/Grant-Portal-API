using AutoMapper;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GMP.API.Controllers
{
    [EnableCors("corspolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UsersController(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var userDomain = await userRepository.GetAllAsync();

            var userDto = mapper.Map<List<UserDto>>(userDomain);

            return Ok(userDto);
        }
    }
}
