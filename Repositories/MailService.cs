using static GMP.API.Repositories.MailService;
using System.Net.Mail;
using System.Net;
using GMP.API.Models.Domain;

namespace GMP.API.Repositories
{
    public class MailService : IMailService
    {
            public async Task<MailData> SendMailAsync(MailData mailData)
            {
                var client = new SmtpClient("smtp.gmail.com", 465)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("duyile35@gmail.com", "Akinlouis@2003")
                };

              await client.SendMailAsync(
                    new MailMessage(from: "duyile35@gmail.com",
                                    to: mailData.Email, mailData.Subject, mailData.Body)
                                    );
               return mailData;
            }
    }
    }
