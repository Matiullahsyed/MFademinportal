using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Models
{
    public class AddNewUser
    {
        [Key]
        public long Admin_ID { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Password { get; set; }
    }
}
