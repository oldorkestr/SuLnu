using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuLnu.BLL.DTO;
using SuLnu.BLL.Interfaces;
using SuLnu.BLL.Services;
using SuLnu.Models;

namespace SuLnu.Controllers
{
    public class MeetingController : Controller
    {
        private Mapper _mapper;

        //public MeetingController(INewsService newsService, IFacultyService facultyService)
        //{
        //    _newsService = newsService;
        //    _facultyService = facultyService;
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>());
        //    this._mapper = new Mapper(config);
        //}

        public IActionResult AllMeetings()
        {
            return View();
        }
    }
}