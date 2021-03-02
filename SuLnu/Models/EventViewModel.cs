using Microsoft.AspNetCore.Http;

namespace SuLnu.Models
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public string FormOfHolding { get; set; }
        public string Location { get; set; }
        public IFormFile ProfilePhotoFilePath { get; set; }
        public string EventType { get; set; }
        public string FacultyName { get; set; }
        public string Description { get; set; }
    }
}