using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.Models;

namespace SuLnu.Controllers
{
    public class EventController: Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            this._mapper = new Mapper(config);
        }
        
        [HttpGet]
        public IActionResult AllNews()
        {
            var AllEventsDTO = _eventService.GetAll();
            var AllEvents = _mapper.Map<IEnumerable<EventViewModel>>(AllEventsDTO);
            return View(AllEvents);
        }
    }
}