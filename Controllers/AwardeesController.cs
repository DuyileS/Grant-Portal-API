using AutoMapper;
using GMP.API.CustomActionFilters;
using GMP.API.Data;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GMP.API.Controllers
{
    [EnableCors("corspolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AwardeesController : ControllerBase
    {
        private readonly IAwardeeRepository awardeeRepository;
        private readonly IMapper mapper;

        public AwardeesController(IAwardeeRepository awardeeRepository, IMapper mapper)
        {
            this.awardeeRepository = awardeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var awardeeDomain = await awardeeRepository.GetAllAsync();
           var awardeeDto = mapper.Map<List<Awardees>>(awardeeDomain);

            return Ok(awardeeDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var awardeeDomain = await awardeeRepository.GetById(id);

            if(awardeeDomain == null)
            {
                return NotFound();
            }

            var awardeeDto = mapper.Map<Awardees>(awardeeDomain);

            return Ok(awardeeDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddAwardeeDto addAwardeeDto)
        {
            var awardeeDomain = mapper.Map<Awardees>(addAwardeeDto);

            awardeeDomain = await awardeeRepository.CreateAsync(awardeeDomain);

            var awardeeDto = mapper.Map<AwardeeDto>(awardeeDomain);

            return CreatedAtAction(nameof(GetById), new { id = awardeeDto.AwardeeId }, awardeeDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAwardeeDto updateAwardeeDto)
        {
            var awardeeDomain = mapper.Map<Awardees>(updateAwardeeDto);

            awardeeDomain = await awardeeRepository.UpdateAsync(id, awardeeDomain);

            if (awardeeDomain == null)
            {
                return NotFound();
            }

            var awardeeDto = mapper.Map<AwardeeDto>(awardeeDomain);
            return Ok(awardeeDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var awardeeDomain = await awardeeRepository.DeleteAsync(id);

            if (awardeeDomain == null)
            {
                return NotFound();
            }

            var awardeeDto = mapper.Map<AwardeeDto>(awardeeDomain);
            return Ok(awardeeDto);
        }
    }
}
