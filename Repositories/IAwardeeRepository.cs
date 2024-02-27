using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public interface IAwardeeRepository
    {
        Task<List<Awardees>> GetAllAsync();
        Task<Awardees?> GetById(int id);
        Task<Awardees> CreateAsync(Awardees awardee);
        Task<Awardees?> UpdateAsync(int id, Awardees awardee);
        Task<Awardees?> DeleteAsync(int id);

    }
}
