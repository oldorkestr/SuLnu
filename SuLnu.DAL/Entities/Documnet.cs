using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuLnu.DAL.Entities
{
    public class Documnet
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentType { get; set; }
        public string FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
