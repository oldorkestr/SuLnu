using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.BLL.Services;
using SuLnu.Models;

namespace SuLnu.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private Mapper _mapper;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>());
            this._mapper = new Mapper(config);
        }

        public IActionResult AllNews()
        {
            var AllNewsDTO = _newsService.GetAll();
            var AllNews = _mapper.Map<IEnumerable<NewsViewModel>>(AllNewsDTO);

            return View(AllNews);
        }
    }
}