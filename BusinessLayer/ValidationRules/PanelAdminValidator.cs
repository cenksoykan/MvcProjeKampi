using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PanelAdminValidator : AbstractValidator<Admin>
    {
        public PanelAdminValidator()
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Kullanıcı parolası boş bırakılamaz");
        }
    }
}
