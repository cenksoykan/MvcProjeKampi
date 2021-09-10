using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PanelWriterValidator : AbstractValidator<Writer>
    {
        public PanelWriterValidator()
        {
            RuleFor(x => x.WriterEmailAddress).NotEmpty().WithMessage("Eposta adresi boş bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Kullanıcı parolası boş bırakılamaz");
        }
    }
}
