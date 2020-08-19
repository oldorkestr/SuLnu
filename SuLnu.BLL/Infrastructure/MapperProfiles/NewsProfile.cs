using AutoMapper;
using SuLnu.BLL.DTO;
using SuLnu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuLnu.BLL.Infrastructure.MapperProfiles
{
    class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
