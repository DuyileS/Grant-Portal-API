using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
        public DateTimeOffset DateUploaded { get; set; }
    }
}
