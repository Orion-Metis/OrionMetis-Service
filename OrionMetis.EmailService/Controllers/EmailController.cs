using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace OrionMetis.EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
       
        [HttpGet]
        public string Get()
        {
            return "email service is running...";
        }

        [HttpPost]
        public void Post([FromBody] Email email)
        {

           
            if (email != null && !string.IsNullOrEmpty(email.EmailAddress))
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Krishna", "krishnav6450@gmail.com"));
                mailMessage.To.Add(new MailboxAddress("X", email.EmailAddress));
                mailMessage.Subject = "Test-Email";
                mailMessage.Body = new TextPart("plain")
                {
                    Text = email.EmailBody
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate("krishnav6450@gmail.com", "V1shwanath");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
            }
        }
    }
}
