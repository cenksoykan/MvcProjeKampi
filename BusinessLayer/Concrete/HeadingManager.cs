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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> List()
        {
            return _headingDal.List();
        }
        public void Insert(Heading writer)
        {
            _headingDal.Insert(writer);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Delete(Heading writer)
        {
            _headingDal.Delete(writer);
        }

        public void Update(Heading writer)
        {
            _headingDal.Update(writer);
        }
    }
}
