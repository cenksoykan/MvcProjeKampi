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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> List()
        {
            return _contentDal.List();
        }

        public List<Content> ListByHeading(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> ListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public void Insert(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
