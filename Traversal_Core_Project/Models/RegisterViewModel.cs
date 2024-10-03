using System.ComponentModel.DataAnnotations;

namespace Traversal_Core_Project.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad kısmı boş geçilemez")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad kısmı boş geçilemez")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı kısmı boş geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email kısmı boş geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre kısmı boş geçilemez")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar kısmı boş geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }


    }
}
