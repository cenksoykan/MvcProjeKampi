using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class StatisticModel
    {
        public int CategoryCount { get; set; }
        public int HeadingCountSoftware { get; set; }
        public int WriterCountFiltered { get; set; }
        public string CategoryTopHeading { get; set; }
        public int CategoryStatusDiff { get; set; }
    }
}