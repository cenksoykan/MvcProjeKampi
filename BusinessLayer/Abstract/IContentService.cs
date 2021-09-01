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
        List<Content> List();
        List<Content> ListByHeading(int id);
        List<Content> ListByWriter(int id);
        void Insert(Content content);
        Content GetById(int id);
        void Update(Content content);
    }
}
