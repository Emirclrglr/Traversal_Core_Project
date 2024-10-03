using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.AnnouncementValidations
{
    public class Add_Announcement_Validator : AbstractValidator<Create_Announcement_DTO>
    {
        public Add_Announcement_Validator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş Geçilemez")
                .MinimumLength(5).WithMessage("Minimum 5 karakter içermelidir")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter içerebilir");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Boş Geçilemez")
                .MinimumLength(20).WithMessage("Minimum 20 karakter içermelidir")
                .MaximumLength(500).WithMessage("Maksimum 500 karakter içerebilir");
        }
    }
}
