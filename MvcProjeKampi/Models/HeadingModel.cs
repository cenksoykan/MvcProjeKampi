using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class HeadingModel
    {
        public string HeadingName { get; set; }
        public int ContentCountActive { get; set; }
        public int ContentCountPassive { get; set; }
    }
}