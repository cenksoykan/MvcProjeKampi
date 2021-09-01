using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactEmailAddress).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz.");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu başlığı boş bırakılamaz.");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("İleti metni boş bırakılamaz.");
        }
    }
}
