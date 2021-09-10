using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminRoleService
    {
        List<AdminRole> List();
        void Insert(AdminRole adminRole);
        void Update(AdminRole adminRole);
    }
}
