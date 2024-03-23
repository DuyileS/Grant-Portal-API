using GMP.API.Models.Domain;
using GMP.API.Models.DTO;

namespace GMP.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
    }
}
