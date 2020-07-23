using System;
using System.ComponentModel.DataAnnotations;

namespace SuLnu.DAL.Entities
{
    public class University
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
            ErrorMessage ="Перевірте правильність пошти!")]
        public string Email { get; set; }

        [StringLength(18, MinimumLength = 18,
            ErrorMessage = "Номер телефону повинен містити 10 цифр")]
        public string PhoneNumber { get; set; }
    }
}
