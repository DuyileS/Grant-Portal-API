using GMP.API.Data;
using GMP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLGrantRepository: IGrantRepository
    {
        private readonly GMPDbContext dbContext;

        public SQLGrantRepository(GMPDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Grant> CreateAsync(Grant grant)
        {
            await dbContext.Grants.AddAsync(grant);
            await dbContext.SaveChangesAsync();
            return grant;
        }

        public async Task<Grant?> DeleteAsync(Guid id)
        {
            var existingGrant = await dbContext.Grants.FirstOrDefaultAsync(x => x.GrantId == id);
            dbContext.Grants.Remove(existingGrant);
            await dbContext.SaveChangesAsync();
            return existingGrant;
        }

        public async Task<List<Grant>> GetAllAsync()
        {
            return await dbContext.Grants.ToListAsync();
        }

        public async Task<Grant?> GetById(Guid id)
        {
            return await dbContext.Grants.FirstOrDefaultAsync(x=> x.GrantId == id);
        }

        public async Task<Grant?> UpdateAsync(Guid id, Grant grant)
        {
            var existingGrant = await dbContext.Grants.FirstOrDefaultAsync(x => x.GrantId == id);

            if (existingGrant == null)
            {
                return null;
            }

            existingGrant.Title = grant.Title;
            existingGrant.Description = grant.Description;
            existingGrant.Amount = grant.Amount;
            existingGrant.Criteria = grant.Criteria;
            existingGrant.Deadline = grant.Deadline;

            await dbContext.SaveChangesAsync();
            return existingGrant;
        }
    }
}
