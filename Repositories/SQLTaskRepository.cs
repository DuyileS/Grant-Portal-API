using GMP.API.Data;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLTaskRepository: ITaskRepository
    {
        private readonly GMPDbContext dbContext;

        public SQLTaskRepository(GMPDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Models.Domain.Task> CreateAsync(Models.Domain.Task task)
        {
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Domain.Task?> DeleteAsync(int id)
        {
            var existingTask = await dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (existingTask == null)
            {
                return null;
            }

            dbContext.Tasks.Remove(existingTask);
            dbContext.SaveChanges();
            return existingTask;
        }

        public async Task<List<Models.Domain.Task>> GetAllAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        public async Task<Models.Domain.Task?> GetById(int id)
        {
            return await dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);
        }

        public async Task<Models.Domain.Task?> UpdateAsync(int id, Models.Domain.Task task)
        {
            var existingTask = await dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (existingTask == null) 
            {
                return null;
            }

            existingTask.TaskName = task.TaskName;
            existingTask.Description = task.Description;
            existingTask.TaskStatus = task.TaskStatus;
            existingTask.AssignedTo = task.AssignedTo;
            existingTask.AssignedFrom = task.AssignedFrom;

            await dbContext.SaveChangesAsync();
            return existingTask;
        }
    }
}
