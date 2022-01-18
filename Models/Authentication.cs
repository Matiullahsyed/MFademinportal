using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Models
{
    public class Authentication
    {
        [Key]
        public long Admin_ID { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Password { get; set; }
        [NotMapped]
        public string User_Token { get; set; }
    }
    public class AlreadyAddedPassword
    {
        public string Admin_Password { get; set; }
    }
    public class PasswordRequestModel
    {
        public long Admin_ID { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Password { get; set; }
    }
}
