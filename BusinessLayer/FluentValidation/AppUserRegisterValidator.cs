using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir")
                .Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir")
                .Equal(y => y.Password).WithMessage("Şifreler uyuşmuyor");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir")
                .MinimumLength(3).WithMessage("Minimum 3 karakter içermelidir");

        }
    }
}
