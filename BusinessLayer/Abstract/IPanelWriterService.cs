using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPanelWriterService
    {
        Writer Auth(string emailAddress, string password);
        string SessionWriter();
        int SessionWriterId();
    }
}
