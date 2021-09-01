using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminRoleProviderService
    {
        string GetRolesForUser(string username);
        bool IsUserInRole(string username, string rolename);
    }
}
