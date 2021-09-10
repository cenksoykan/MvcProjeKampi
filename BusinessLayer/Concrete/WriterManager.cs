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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> List()
        {
            return _writerDal.List();
        }

        public void Insert(Writer writer)
        {
            string password = writer.WriterPassword;
            writer.WriterPassword = HashManager.SHA1(password);
            _writerDal.Insert(writer);
        }

        public Writer GetById(int id = 0)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public void Update(Writer writer)
        {
            string password = writer.WriterPassword;
            writer.WriterPassword = HashManager.SHA1(password);
            _writerDal.Update(writer);
        }
    }
}
