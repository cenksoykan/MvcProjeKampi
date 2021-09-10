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
    public class AdminRoleProviderManager : IAdminRoleProviderService
    {
        IAdminRoleProviderDal _adminRoleProviderDal;

        public AdminRoleProviderManager(IAdminRoleProviderDal adminRoleProviderDal)
        {
            _adminRoleProviderDal = adminRoleProviderDal;
        }

        public string GetRolesForUser(string username)
        {
            return _adminRoleProviderDal.Get(x => x.AdminUsername == username).AdminRoleCode;
        }

        public bool IsUserInRole(string username, string rolename)
        {
            return _adminRoleProviderDal.Get(x => x.AdminUsername == username && x.AdminRoleCode == rolename) == null;
        }
    }
}
