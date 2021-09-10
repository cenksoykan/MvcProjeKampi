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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<Admin> List()
        {
            return _adminDal.List();
        }

        public void Insert(Admin admin)
        {
            string password = admin.AdminPassword;
            admin.AdminPassword = HashManager.SHA1(password);
            _adminDal.Insert(admin);
        }

        public Admin GetById(int id = 0)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public void Update(Admin admin)
        {
            string password = admin.AdminPassword;
            admin.AdminPassword = HashManager.SHA1(password);
            _adminDal.Update(admin);
        }
    }
}
