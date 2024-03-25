using GMP.API.Models.Domain;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailService mailService;

        public MailsController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] MailData mailData) 
        {
            await mailService.SendMailAsync(mailData);

            return Ok(mailData);
            
        }
    }
}
