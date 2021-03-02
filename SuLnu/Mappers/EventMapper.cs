using SuLnu.BLL.DTO;
using SuLnu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuLnu.Mappers
{
    public class EventMapper
    {
        public static EventDTO Mapper(EventViewModel @event, string image, int facultyId)
        {
            return new EventDTO
            {
                Name = @event.Name,
                Description = @event.Description,
                FormOfHolding = @event.FormOfHolding,
                Location = @event.Location,
                ProfilePhotoFilePath = image,
                EventType = @event.EventType,
                FacultyId = facultyId
            };
        }
    }
}