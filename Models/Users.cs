using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Models
{
    public class Users
    {
        public long User_ID { get; set; }
        public string User_Joined_Email { get; set; }
        public string Name { get; set; }
        public DateTime Logged_DateTime { get; set; }
        public string Note { get; set; }
        public long Company_ID { get; set; }
        public int TotalRecords { get; set; }
    }
}
