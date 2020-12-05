using System.Collections.Generic;
using SuLnu.BLL.DTO;

namespace SuLnu.BLL.Interfaces
{
    public interface IEventService
    {
        public IEnumerable<EventDTO> GetAll();
        public void CreateNews(EventDTO eventDto);
    }
}