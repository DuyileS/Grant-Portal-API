using GMP.API.Data;
using GMP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLAwardeeRepository: IAwardeeRepository
    {
        private readonly GMPDbContext dbContext;

        public SQLAwardeeRepository(GMPDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Awardees> CreateAsync(Awardees awardee)
        {
            await dbContext.Awardees.AddAsync(awardee);
            await dbContext.SaveChangesAsync();
            return awardee;
        }

        public async Task<Awardees?> DeleteAsync(int id)
        {
            var existingAwardee = await dbContext.Awardees.FirstOrDefaultAsync(x => x.AwardeeId == id);
            if (existingAwardee == null) 
            {
                return null;
            }

            dbContext.Awardees.Remove(existingAwardee);
            await dbContext.SaveChangesAsync();
            return existingAwardee;
        }

        public async Task<List<Awardees>> GetAllAsync()
        {
            return await dbContext.Awardees.ToListAsync();
        }

        public async Task<Awardees?> GetById(int id)
        {
            return await dbContext.Awardees.FirstOrDefaultAsync(x => x.AwardeeId == id);
        }

        public async Task<Awardees?> UpdateAsync(int id, Awardees awardee)
        {
            var existingAwardee = await dbContext.Awardees.FirstOrDefaultAsync(x => x.AwardeeId == id);
            if (existingAwardee == null) 
            {
                return null;
            }

            existingAwardee.FirstName = awardee.FirstName;
            existingAwardee.LastName = awardee.LastName;
            existingAwardee.PhoneNumber = awardee.PhoneNumber;
            existingAwardee.Email = awardee.Email;
            existingAwardee.AreaOfSpecialization = awardee.AreaOfSpecialization;
            existingAwardee.Amount = awardee.Amount;

            await dbContext.SaveChangesAsync();
            return existingAwardee;
        }
    }
}
