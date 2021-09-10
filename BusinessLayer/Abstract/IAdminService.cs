using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> List();
        void Insert(Admin admin);
        Admin GetById(int id);
        void Update(Admin admin);
    }
}
