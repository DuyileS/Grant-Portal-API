using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public interface IGrantRepository
    {
        Task<List<Grant>> GetAllAsync();
        Task<Grant?> GetById(Guid id);
        Task<Grant> CreateAsync(Grant grant);
        Task<Grant?> UpdateAsync(Guid id, Grant grant);
        Task<Grant?> DeleteAsync(Guid id);
    }
}
