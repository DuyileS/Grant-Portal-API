using GMP.API.Data;
using GMP.API.Models.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace GMP.API.Repositories
{
    public class SQLDocumentRepository: IDocumentRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly GMPDbContext dbContext;

        public SQLDocumentRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, GMPDbContext dbContext) 
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

       

        public async Task<Document> UploadAsync(Document document)
        {

            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Documents",
                                                   $"{document.Title}{document.FileExtension}");

            //Upload image to Local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await document.File.CopyToAsync(stream);

            //To return url to file location on the host
            //https://localhost:1234/Images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{document.Title}{document.FileExtension}";

            document.FilePath = urlFilePath;

            //Add changes to Images table
            await dbContext.Documents.AddAsync(document);
            await dbContext.SaveChangesAsync();

            return document;

        }
    }
}
