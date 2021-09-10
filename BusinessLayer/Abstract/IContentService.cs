using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> List(string q);
        List<Content> ListByHeading(int id, string q);
        List<Content> ListByWriter(int id, string q);
        void Insert(Content content);
        Content GetById(int id);
        void Update(Content content);
    }
}
