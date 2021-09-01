using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> List();
        void Insert(Contact contact);
        Contact GetById(int id);
        void Update(Contact contact);
    }
}
