using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.Models;

namespace SuLnu.Controllers
{
    public class EventController: Controller
    {
        private readonly IEventService _eventService;
        private readonly IFacultyService _facultyService;
        private readonly IImageService _imageService;
        private Mapper _mapper;

        public EventController(IEventService eventService, IImageService imageService, IFacultyService facultyService)
        {
            _eventService = eventService;
            _facultyService = facultyService;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            _mapper = new Mapper(config);
            _imageService = imageService;
        }
        
        public IActionResult AllEvents()
        {
            var AllEventsDTO = _eventService.GetAll();
            var AllEvents = _mapper.Map<IEnumerable<EventViewModel>>(AllEventsDTO);
            return View(AllEvents);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            var faculties = new SelectList(_facultyService.GetAllFacultiesNames().ToList().Append("All"));
            ViewBag.faculties = faculties;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel @event)
        {
            int facultyId = Convert.ToInt32(_facultyService.GetFacultyIdByName(@event.FacultyName));

            string image = "";
            if (@event.ProfilePhotoFilePath != null)
            {
                var imageSrc = await _imageService.SaveImage(@event.ProfilePhotoFilePath);
                image = imageSrc;
            }

            var eventDTO = new EventDTO
            {
                Name = @event.Name,
                Description = @event.Description,
                FormOfHolding = @event.FormOfHolding,
                Location = @event.Location,
                ProfilePhotoFilePath = image,
                EventType = @event.EventType,
                FacultyId = facultyId
            };

            _eventService.CreateEvents(eventDTO);
            return RedirectToAction("AllEvents", "Event");
        }
    }
}