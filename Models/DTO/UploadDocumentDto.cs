using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMP.API.Models.DTO
{
    public class UploadDocumentDto
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public IFormFile File { get; set; }
        public string? FileExtension { get; set; }
        public long? FileSizeInBytes { get; set; }
        public string? FilePath { get; set; }
    }
}
