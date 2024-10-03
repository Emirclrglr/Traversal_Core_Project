using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Core_Project.Models;

namespace Traversal_Core_Project.Controllers
{
    [AllowAnonymous]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ChangePasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassword_VM forgetPassword_VM)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword_VM.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "ChangePassword", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress("Admin", "emirhancalaraglar@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User", forgetPassword_VM.Mail));

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";



            SmtpClient smtpClient = new();

            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("emirhancalaraglar@gmail.com", "hqauobvldqokhofd");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);



            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid; 
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword_VM model)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (userid == null || token == null)
            {
                // hata mesajı
            }

            var user = await _userManager.FindByIdAsync(userid.ToString());

            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }
    }
}
