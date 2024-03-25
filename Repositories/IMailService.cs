using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public interface IMailService
    {
        Task<MailData> SendMailAsync(MailData mailData);
    }
}
