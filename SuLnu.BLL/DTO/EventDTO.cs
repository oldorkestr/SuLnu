namespace SuLnu.BLL.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FormOfHolding { get; set; }
        public string Location { get; set; }
        public string ProfilePhotoFilePath { get; set; }
        public string EventType { get; set; }
        public int FacultyId { get; set; }
    }
}