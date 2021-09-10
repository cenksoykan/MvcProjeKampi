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
    public class PanelWriterManager : IPanelWriterService
    {
        IWriterDal _writerDal;
        string _sessionWriter;

        public PanelWriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
            _sessionWriter = HttpContext.Current.Session["WriterEmailAddress"]?.ToString();
        }

        public Writer Auth(string emailAddress, string password)
        {
            var hash = HashManager.SHA1(password);
            return _writerDal.Get(x => x.WriterEmailAddress == emailAddress && x.WriterPassword == hash && x.WriterStatus);
        }

        public string SessionWriter()
        {
            return _sessionWriter ?? String.Empty;
        }

        public int SessionWriterId()
        {
            string writerEmailAddress = SessionWriter();
            Writer writerValues = _writerDal.Get(x => x.WriterEmailAddress == writerEmailAddress);
            return writerValues?.WriterId ?? 0;
        }
    }
}
