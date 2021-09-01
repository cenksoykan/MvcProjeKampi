using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> List();
        List<Heading> ListByWriter(int id);
        void Insert(Heading heading);
        Heading GetById(int id);
        void Update(Heading heading);
    }
}
