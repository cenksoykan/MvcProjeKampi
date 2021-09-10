using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.AdminUsername).Matches("^[a-zA-Z0-9]*$").WithMessage("Kullanıcı adı özel karakter içeremez");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Lütfen parola belirleyiniz");
        }
    }
}
