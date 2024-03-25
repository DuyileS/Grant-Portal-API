using AutoMapper;
using GMP.API.Data;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Controllers
{
    [EnableCors("corspolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly GMPAuthDbContext dbContext;

        public UsersController(IMapper mapper, UserManager<IdentityUser> userManager, GMPAuthDbContext dbContext)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userDomain = await userManager.Users.ToListAsync();

            var userDto = mapper.Map<List<UserDto>>(userDomain);

            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var userDomain = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDto>(userDomain);

            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var userDomain = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(userDomain);
           await dbContext.SaveChangesAsync();

            var userDto = mapper.Map<UserDto>(userDomain);

            return Ok(userDto);

        }
    }
}
