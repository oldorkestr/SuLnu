using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuLnu.DAL.Entities
{
    public class Faculty
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Перевірте правильність пошти!")]
        public string Email { get; set; }
        public string Description { get; set; }
        public string LogoFilePath { get; set; }
        public string UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<Document> Documnets { get; set; }
    }
}
