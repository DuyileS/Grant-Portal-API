using GMP.API.Data;
using GMP.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLUserRepository: IUserRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly GMPAuthDbContext dbContext;

        public SQLUserRepository(UserManager<IdentityUser> userManager, GMPAuthDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<List<IdentityUser>> GetAllAsync()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}
