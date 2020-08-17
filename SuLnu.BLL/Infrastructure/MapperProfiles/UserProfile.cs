using System;
using System.Collections.Generic;
using System.Text;
using SuLnu.BLL.DTO;
using SuLnu.DAL.Entities;
using AutoMapper;

namespace SuLnu.BLL.Infrastructure.MapperProfiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>();
            CreateMap<UserDTO, AppUser>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}