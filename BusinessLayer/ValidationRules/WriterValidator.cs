using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında içeriği boş bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Lütfen parola belirleyiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvan içeriği boş bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
            RuleFor(x => x.WriterEmailAddress).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.WriterName).Matches("[Aa]").WithMessage("Yazar adında 'a' karakteri bulunması gerekmektedir");
        }
    }
}
