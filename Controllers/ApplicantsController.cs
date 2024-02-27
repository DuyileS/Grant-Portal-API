using AutoMapper;
using GMP.API.CustomActionFilters;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantRepository applicantRepository;
        private readonly IMapper mapper;

        public ApplicantsController(IApplicantRepository applicantRepository, IMapper mapper)
        {
            this.applicantRepository = applicantRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applicantDomain = await applicantRepository.GetAllAsync();

            var applicantDto = mapper.Map<List<ApplicantDto>>(applicantDomain);

            return Ok(applicantDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var applicantDomain = await applicantRepository.GetById(id);

            if(applicantDomain == null) 
            {
                return NotFound();
            }

            var applicantDto = mapper.Map<ApplicantDto>(applicantDomain);

            return Ok(applicantDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddApplicantDto addApplicantDto)
        {
            var applicantDomain = mapper.Map<Applicant>(addApplicantDto);

             applicantDomain = await applicantRepository.CreateAsync(applicantDomain);

            var applicantDto = mapper.Map<ApplicantDto>(applicantDomain);

            return CreatedAtAction(nameof(GetById), new { id = applicantDto.ApplicantId }, applicantDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateApplicantDto updateApplicantDto)
        {
            var applicantDomain = mapper.Map<Applicant>(updateApplicantDto);

            applicantDomain = await applicantRepository.UpdateAsync(id, applicantDomain);

            if (applicantDomain == null) 
            {
                return NotFound();
            }

            var applicantDto = mapper.Map<ApplicantDto>(applicantDomain);
            return Ok(applicantDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var applicantDomain = await applicantRepository.DeleteAsync(id);

            if (applicantDomain == null)
            {
                return NotFound();
            }

            var applicantDto = mapper.Map<ApplicantDto>(applicantDomain);
            return Ok(applicantDto);
        }
    }
}
