using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık adı boş bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Başlık kategorisi boş bırakılamaz");
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Başlık yazarı boş bırakılamaz");
        }
    }
}
