using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuLnu.DataAccess.Entities.User
{
    public class Education
    {
        public string ID { get; set; }

        [Display(Name = "Місце навчання")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,51}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,51})*$",
            ErrorMessage = "Місце навчання має містити тільки літери")]
        public string PlaceOfStudy { get; set; }

        [Display(Name = "Спеціальність")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,51}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,51})*$",
            ErrorMessage = "Спеціальність має містити тільки літери")]
        public string Speciality { get; set; }

        [Display(Name = "Група")]
        public string Group { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
