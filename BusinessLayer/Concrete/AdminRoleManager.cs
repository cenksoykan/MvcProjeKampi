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
    public class AdminRoleManager : IAdminRoleService
    {
        IAdminRoleDal _adminRoleDal;

        public AdminRoleManager(IAdminRoleDal adminRoleDal)
        {
            _adminRoleDal = adminRoleDal;
        }

        public List<AdminRole> List()
        {
            return _adminRoleDal.List().Where(x => !x.AdminRoleCode.Equals("S")).OrderByDescending(x => x.AdminRoleCode).ToList();
        }

        public void Insert(AdminRole adminRole)
        {
            _adminRoleDal.Insert(adminRole);
        }

        public void Update(AdminRole adminRole)
        {
            _adminRoleDal.Update(adminRole);
        }
    }
}
