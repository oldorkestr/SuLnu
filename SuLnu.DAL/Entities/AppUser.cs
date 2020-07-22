using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuLnu.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser() { }
        public AppUser(string firstName, string lastName, int course, string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            ImagePath = imagePath;
        }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public int Course { get; set; }

        public string ImagePath { get; set; }
    }
}
