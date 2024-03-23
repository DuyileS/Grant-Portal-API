using AutoMapper;
using GMP.API.CustomActionFilters;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace GMP.API.Controllers
{
    [EnableCors("corspolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;

        public DocumentsController(IDocumentRepository documentRepository, IMapper mapper) 
        {
            this.documentRepository = documentRepository;
            this.mapper = mapper;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentDomain = await documentRepository.GetAllAsync();

            var documentDto = mapper.Map<List<DocumentDto>>(documentDomain);

            return Ok(documentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var documentDomain = await documentRepository.GetById(id);

            if (documentDomain == null)
            {
                return NotFound();
            }

            var documentDto = mapper.Map<Document>(documentDomain);

            return Ok(documentDto);
        }
    }
}
