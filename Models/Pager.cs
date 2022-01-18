using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Models
{
    public class Pager
    {
        public List<Users> Users { get; set; }
        public int CurrentPageIndex { get; set; }
        public int TotalPageCount { get; set; }
        public int PerPageCount { get; set; }
    }
}
