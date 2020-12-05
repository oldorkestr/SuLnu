﻿using System.Collections.Generic;
using AutoMapper;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.DAL.Entities;
using SuLnu.DAL.Interfaces;

namespace SuLnu.BLL.Services
{
    public class EventService: IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService()
        { }
        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EventDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Event>, List<EventDTO>>(_unitOfWork.Events.GetAll());
        }

        public void CreateNews(EventDTO eventDto)
        {
            throw new System.NotImplementedException();
        }
    }
}