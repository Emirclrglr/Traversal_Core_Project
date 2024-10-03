using DTOLayer.DTOs.FeatureDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.FeatureValidations
{
    public class Update_Feature_Validator:AbstractValidator<Update_Feature_DTO>
    {
        public Update_Feature_Validator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçilemez")
                .MinimumLength(5).WithMessage("En az 5 karakter içermelidir")
                .MaximumLength(50).WithMessage("En fazla 50 karakter içerebilir");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş geçilemez")
                .MinimumLength(5).WithMessage("En az 5 karakter içermelidir")
                .MaximumLength(50).WithMessage("En fazla 50 karakter içerebilir");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
