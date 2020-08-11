using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuLnu.Models
{
    public class RegisterInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Course { get; set; }

        public string Faculty { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
