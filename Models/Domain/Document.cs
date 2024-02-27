using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMP.API.Models.Domain
{
    public class Document
    {

        public Document()
        {
            DateUploaded = DateTimeOffset.UtcNow;
        }

        [Key]
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
