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

        public List<Content> List(string q = null)
        {
            if (String.IsNullOrEmpty(q)) return _contentDal.List();
            string[] words = q.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return _contentDal.List(x => words.All(w => x.ContentValue.Contains(w) || x.Heading.HeadingName.Contains(w) || x.Writer.WriterName.Contains(w)));
        }

        public List<Content> ListByHeading(int id = 0, string q = null)
        {
            if (String.IsNullOrEmpty(q)) return _contentDal.List(x => x.HeadingId == id);
            string[] words = q.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return _contentDal.List(x => x.HeadingId == id && words.All(w => x.ContentValue.Contains(w) || x.Heading.HeadingName.Contains(w) || x.Writer.WriterName.Contains(w)));
        }

        public List<Content> ListByWriter(int id = 0, string q = null)
        {
            if (String.IsNullOrEmpty(q)) return _contentDal.List(x => x.WriterId == id);
            string[] words = q.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return _contentDal.List(x => x.WriterId == id && words.All(w => x.ContentValue.Contains(w) || x.Heading.HeadingName.Contains(w) || x.Writer.WriterName.Contains(w)));
        }

        public void Insert(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetById(int id = 0)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
