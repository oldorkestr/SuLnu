using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SuLnu.DataAccess.Entities.User
{
    public class User : IdentityUser
    {
        [Display(Name = "Ім'я")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26})*$",
            ErrorMessage = "Ім'я має містити тільки літери")]
        [Required(ErrorMessage = "Поле ім'я є обов'язковим")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ім'я повинне складати від 2 до 25 символів")]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26})*$",
            ErrorMessage = "Прізвище має містити тільки літери")]
        [Required(ErrorMessage = "Поле прізвище є обов'язковим")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Прізвище повинне складати від 2 до 25 символів")]
        public string LastName { get; set; }

        [Display(Name = "По-батькові")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26})*$",
            ErrorMessage = "По-батькові має містити тільки літери")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Поле по-батькові повинне складати від 2 до 25 символів")]
        public string FatherName { get; set; }

        [Display(Name = "Номер телефону")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Номер телефону повинен містити 10 цифр")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        public DateTime RegistredOn { get; set; }

        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата народження")]
        public DateTime Birthday { get; set; }

        public string EducationId { get; set; }
        public Education Education { get; set; }
    }
}
