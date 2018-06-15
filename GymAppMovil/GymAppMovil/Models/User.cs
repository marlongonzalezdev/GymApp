using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppMovil.Models
{
    public class User
    {        
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? ModifiedBy { get; set; }
        public int RoleID { get; set; }
    }
}
