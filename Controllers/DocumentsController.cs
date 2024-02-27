using GMP.API.CustomActionFilters;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentsController(IDocumentRepository documentRepository) 
        {
            this.documentRepository = documentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadDocumentDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //Convert DTO to Domain model
                var documentDomainModel = new Document
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    Title = request.Title,
                    Description = request.Description,
                };

                documentDomainModel = await documentRepository.UploadAsync(documentDomainModel);
                return Ok(documentDomainModel);
            }else 
            {
                return BadRequest(ModelState);
            }

        }
            private void ValidateFileUpload(UploadDocumentDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".pdf", ".docx" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 104857600)
            {
                ModelState.AddModelError("file", "File cannot be larger than 100MB");
            }
        }

    }
}
