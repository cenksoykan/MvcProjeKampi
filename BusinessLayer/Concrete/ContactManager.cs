using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> List(string q = null)
        {
            var messages = String.IsNullOrEmpty(q) ? _contactDal.List() : _contactDal.List(m => m.ContactEmailAddress.Contains(q) || m.ContactUserName.Contains(q) || m.ContactSubject.Contains(q) || m.ContactMessage.Contains(q));

            return messages.OrderByDescending(x => x.ContactDate)
                .ThenByDescending(x => x.ContactId)
                .ToList();
        }
        public void Insert(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public Contact GetById(int id = 0)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
