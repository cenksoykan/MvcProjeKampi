using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GalleryImageValidator : AbstractValidator<GalleryImage>
    {
        public GalleryImageValidator()
        {
            RuleFor(x => x.GalleryImageName).NotEmpty().WithMessage("Resim adı boş bırakılamaz");
            RuleFor(x => x.GalleryImageName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
        }
    }
}
