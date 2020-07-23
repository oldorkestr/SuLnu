using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuLnu.DAL.Entities
{
    public class Event
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FormOfHolding { get; set; }
        public string Location { get; set; }
        public string ProfilePhotoFilePath { get; set; }
        public string EventType { get; set; }
        public string FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
