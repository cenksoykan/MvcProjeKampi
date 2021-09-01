using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> List();
        void Insert(Writer writer);
        Writer GetById(int id);
        void Update(Writer writer);
    }
}
