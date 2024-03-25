using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace GMP.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<IdentityUser>> GetAllAsync();
    }
}
