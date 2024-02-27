using GMP.API.Models.Domain;
using Task = GMP.API.Models.Domain.Task;

namespace GMP.API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Task>> GetAllAsync();
        Task<Task?> GetById(int id);
        Task<Task> CreateAsync(Task task);
        Task<Task?> UpdateAsync(int id, Task task);
        Task<Task?> DeleteAsync(int id);
    }
}
