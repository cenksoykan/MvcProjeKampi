using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageReceiver).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("İleti içeriği boş bırakılamaz");
            RuleFor(x => x.MessageReceiver).MaximumLength(500).WithMessage("Alıcı eposta adresi en fazla 500 karakter olabilir");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olabilir");
            RuleFor(x => x.MessageBody).MaximumLength(8000).WithMessage("İleti içeriği en fazla 8000 karakter olabilir");
        }
    }
}
