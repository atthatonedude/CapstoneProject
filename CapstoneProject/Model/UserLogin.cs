using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject.Model
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }


    }
}
