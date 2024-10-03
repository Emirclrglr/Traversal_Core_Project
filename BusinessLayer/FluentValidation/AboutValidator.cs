using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("- Açıklama kısmını boş geçemezsiniz");
            RuleFor(x => x.Image11).NotEmpty().WithMessage("- Lütfen görsel seçiniz");
            RuleFor(x => x.Description1).MinimumLength(50).WithMessage("- En az 50 karakterlik veri girişi yapabilirsiniz");
            RuleFor(x => x.Description1).MaximumLength(1500).WithMessage("- En fazla 1500 karakterlik veri girişi yapabilirsiniz");
        }
    }
}
