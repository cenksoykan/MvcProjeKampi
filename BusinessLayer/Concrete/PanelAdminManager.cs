using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Concrete
{
    public class PanelAdminManager : IPanelAdminService
    {
        IAdminDal _adminDal;
        string _sessionAdmin;

        public PanelAdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
            _sessionAdmin = HttpContext.Current.Session["AdminUsername"]?.ToString();
        }

        public Admin Auth(string username, string password)
        {
            var hash = HashManager.SHA1(password);
            return _adminDal.Get(x => x.AdminUsername == username && x.AdminPassword == hash && (x.AdminStatus || x.AdminRoleCode == "S"));
        }

        public string SessionAdmin()
        {
            return _sessionAdmin ?? String.Empty;
        }

        public int SessionAdminId()
        {
            string adminUserName = SessionAdmin();
            Admin adminValues = _adminDal.Get(x => x.AdminUsername == adminUserName);
            return adminValues?.AdminId ?? 0;
        }
    }
}
