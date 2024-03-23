using GMP.API.Data;
using GMP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Repositories
{
    public class SQLApplicantRepository : IApplicantRepository
    {
        private readonly GMPDbContext dbContext;

        public SQLApplicantRepository(GMPDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Applicant> CreateAsync(Applicant applicant)
        {
           await dbContext.Applicants.AddAsync(applicant);
            await dbContext.SaveChangesAsync();
            return applicant;
        }

        public async Task<Applicant> DeleteAsync(int id)
        {
          var existingApplicant = await dbContext.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == id);
            dbContext.Applicants.Remove(existingApplicant);
            await dbContext.SaveChangesAsync();
            return existingApplicant;
        }

        public async Task<List<Applicant>> GetAllAsync()
        {
           return await dbContext.Applicants.ToListAsync();
        }

        public async Task<Applicant> GetById(int id)
        {
            return await dbContext.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == id);
        }

        public async Task<Applicant?> UpdateAsync(int id, Applicant applicant)
        {
            var existingApplicant = await dbContext.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == id);

            if (existingApplicant == null)
            {
                return null;
            }

            existingApplicant.FirstName = applicant.FirstName;
            existingApplicant.LastName = applicant.LastName;
            existingApplicant.Title = applicant.Title;
            existingApplicant.Department = applicant.Department;
            existingApplicant.Email = applicant.Email;
            existingApplicant.PhoneNumber = applicant.PhoneNumber;
            existingApplicant.Status = applicant.Status;
            existingApplicant.IsStaffMember = applicant.IsStaffMember;

            await dbContext.SaveChangesAsync();
            return existingApplicant;
        }

        public async Task<Applicant?> UploadDocumentAsync(int id, Applicant applicant) 
        {
            var existingApplicant = await dbContext.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == id);

            if (existingApplicant == null)
            {
                return null;
            }

            existingApplicant.DocumentId = applicant.DocumentId;

            await dbContext.SaveChangesAsync();
            return existingApplicant;
        }
    }
    
}
