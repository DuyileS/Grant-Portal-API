using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public interface IDocumentRepository
    {
        Task<Document> UploadAsync(Document document);
        Task<List<Document>> GetAllAsync();

        Task<Document?> GetById(int id);
    }
}
