using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Core_Project.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequestVM model)
        {
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress("Admin","emirhancalaraglar@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User",model.ReceiverMail));
            
            mimeMessage.Subject = model.Subject;

            mimeMessage.Body = new TextPart("plain")
            {
                Text = model.Content
            };

            SmtpClient smtpClient = new();

            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("emirhancalaraglar@gmail.com", "hqauobvldqokhofd");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
