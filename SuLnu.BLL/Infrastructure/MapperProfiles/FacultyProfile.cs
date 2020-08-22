using AutoMapper;
using SuLnu.BLL.DTO;
using SuLnu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuLnu.BLL.Infrastructure.MapperProfiles
{
    class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, FacultyDTO>();
            CreateMap<FacultyDTO, Faculty>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
