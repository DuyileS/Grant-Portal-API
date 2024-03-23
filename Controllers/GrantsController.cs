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

namespace GMP.API.Controllers
{
    [EnableCors("corspolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private readonly IGrantRepository grantRepository;
        private readonly IMapper mapper;

        public GrantsController(IGrantRepository grantRepository, IMapper mapper)
        {
            this.grantRepository = grantRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grantDomain = await grantRepository.GetAllAsync();

            var grantDto = mapper.Map<List<GrantDto>>(grantDomain);
            return Ok(grantDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var grantDomain = await grantRepository.GetById(id);

            if (grantDomain == null)
            {
                return NotFound();
            }

            var grantDto = mapper.Map<GrantDto>(grantDomain);
            return Ok(grantDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddGrantRequestDto addGrantRequestDto)
        {
            var grantDomain = mapper.Map<Grant>(addGrantRequestDto);

            grantDomain = await grantRepository.CreateAsync(grantDomain);
            var grantDto = mapper.Map<GrantDto>(grantDomain);

            return CreatedAtAction(nameof(GetById), new { id = grantDto.GrantId }, grantDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGrantRequestDto updateGrantRequestDto)
        {
            var grantDomain = mapper.Map<Grant>(updateGrantRequestDto);

            grantDomain = await grantRepository.UpdateAsync(id, grantDomain);

            if (grantDomain == null)
            {
                return NotFound();
            }

            var grantDto = mapper.Map<GrantDto>(grantDomain);
            return Ok(grantDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var grantDomain = await grantRepository.DeleteAsync(id);

            if (grantDomain == null)
            {
                return NotFound();
            }

            var grantDto = mapper.Map<GrantDto>(grantDomain);
            return Ok(grantDto);
        }
    }
}
