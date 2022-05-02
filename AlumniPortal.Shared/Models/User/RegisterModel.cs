using System;
using System.Collections.Generic;
using System.Text;

namespace AlumniPortal.Shared.Models
{
   public class RegisterModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
