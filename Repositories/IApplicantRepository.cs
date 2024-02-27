using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public interface IApplicantRepository
    {
        Task<List<Applicant>> GetAllAsync();
        Task<Applicant?> GetById(int id);
        Task<Applicant> CreateAsync(Applicant applicant);
        Task<Applicant?> UpdateAsync(int id, Applicant applicant);
        Task<Applicant?> DeleteAsync(int id);
        Task<Applicant?> UploadDocumentAsync(int id, Applicant applicant);
    }
}

