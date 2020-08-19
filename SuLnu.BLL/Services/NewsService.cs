using AutoMapper;
using Microsoft.Extensions.Logging;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.DAL.Entities;
using SuLnu.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuLnu.BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService() {}

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NewsDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<News>, List<NewsDTO>>(_unitOfWork.News.GetAll());
        }
    }
}
