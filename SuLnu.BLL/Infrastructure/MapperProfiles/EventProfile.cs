using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SuLnu.BLL.DTO;
using SuLnu.DAL.Entities;

namespace SuLnu.BLL.Infrastructure.MapperProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
