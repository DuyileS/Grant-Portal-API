using GMP.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLUserRepository: IUserRepository
    {
        private readonly UserManager<User> userManager;

        public SQLUserRepository(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}
