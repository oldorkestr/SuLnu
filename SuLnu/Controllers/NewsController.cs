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
        public IActionResult CreateNews()
        {
            //var viewModel = new NewsViewModel
            //{
            //    News = this._newsService.GetAll().ToList(),
            //};

            return this.View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateNews(NewsViewModel newsInput)
        {
            var newsDTO = new NewsDTO
            {
                Tilte = newsInput.Tilte,
                Description = newsInput.Description,
                PhotoFilePath = newsInput.PhotoFilePath,
            };

            this._newsService.CreateNews(newsDTO);

            //if (newsInput.Tilte != null)
            //{
            //    foreach (var tag in newsInput.Tags)
            //    {
            //        var tagId = this._tagService.FindOrCreate(tag);
            //        this._questionService.AddTag(questionDTO.Id, tagId);
            //    }
            //}

            //this._logger.LogInformation($"Question #{questionDTO.Id} created.");

            return this.RedirectToAction("News", "AllNews");
        }
    }
}