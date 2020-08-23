﻿using System;
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
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IFacultyService _facultyService;
        private readonly IImageService _imageService;
        private Mapper _mapper;

        public NewsController(INewsService newsService, IImageService imageService, IFacultyService facultyService)
        {
            _newsService = newsService;
            _facultyService = facultyService;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsShortViewModel>());
            this._mapper = new Mapper(config);
            this._imageService = imageService;
        }

        public IActionResult AllNews()
        {
            var AllNewsDTO = _newsService.GetAll();
            var AllNews = _mapper.Map<IEnumerable<NewsShortViewModel>>(AllNewsDTO);
            return View(AllNews);
        }
        public IActionResult CreateNews()
        {
            var nameFaculties = new SelectList(_facultyService.GetAllFacultiesNames().ToList());
            this.ViewBag.faculties = nameFaculties;
            return this.View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNews(NewsViewModel newsInput)
        {
            var nameFaculties = new SelectList(_facultyService.GetAllFacultiesNames().ToList());
            this.ViewBag.faculties = nameFaculties;
            var facultyId = _facultyService.GetFacultyIdByName(newsInput.FacultyName);
            var newsId = 2;
            string image = "";
            if (newsInput.Image != null)
            {
                var imageSrc = await this._imageService.SaveImage(newsInput.Image);
                image = imageSrc;
                this._newsService.UpdateImage(newsId, imageSrc);
            }
            var newsDTO = new NewsDTO
            {
                Tilte = newsInput.Tilte,
                Description = newsInput.Description,
                FacultyId = facultyId,
                PhotoFilePath= image
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

            return this.RedirectToAction("AllNews", "News");
        }
    }
}