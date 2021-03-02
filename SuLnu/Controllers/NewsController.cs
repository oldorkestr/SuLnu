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

        public IActionResult AllNews(string? filterString, string? sortOrder, string? currentFilter, int page = 1)
        {
            var AllNewsDTO = _newsService.GetAll();
            var AllNews = _mapper.Map<IEnumerable<NewsShortViewModel>>(AllNewsDTO);
            foreach (var news in AllNews)
            {
                news.FacultyName = _facultyService.GetFacultyNameById(news.FacultyId);
            }

            ViewBag.CurrentSort = sortOrder;

            if (filterString != null)
            {
                page = 1;
            }
            else
            {
                filterString = currentFilter;
            }

            ViewBag.CurrentFilter = filterString;

            var faculties = new SelectList(_facultyService.GetAllFacultiesNames().ToList().Append("All news"));
            ViewBag.faculties = faculties;

            if (!String.IsNullOrEmpty(filterString) && filterString!="All news")
            {
                AllNews = AllNews.Where(n => n.FacultyName.ToLower().Contains(filterString.ToLower()));
            }

            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "Name":
                    AllNews = AllNews.OrderBy(s => s.Tilte);
                    break;
                case "name_desc":
                    AllNews = AllNews.OrderByDescending(s => s.Tilte);
                    break;
                case "Date":
                    AllNews = AllNews.OrderBy(s => s.CreationDate);
                    break;
                case "date_desc":
                    AllNews = AllNews.OrderByDescending(s => s.CreationDate);
                    break;
                default:
                    AllNews = AllNews.OrderBy(s => s.CreationDate);
                    break;
            }


            int maxRows = 6;
            var newsPerPages = AllNews.Skip((page - 1) * maxRows).Take(maxRows);
            double pageCount = (int)Math.Ceiling((decimal)AllNews.Count() / maxRows);
            PagedViewModel pagedQuestions = new PagedViewModel { PageCount = (int)Math.Ceiling(pageCount), CurrentPageIndex = page, News = newsPerPages };
            return View(pagedQuestions);
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
            string image = "";
            if (newsInput.Image != null)
            {
                var imageSrc = await this._imageService.SaveImage(newsInput.Image);
                image = imageSrc;
            }

            var newsDTO = new NewsDTO
            {
                Tilte = newsInput.Tilte,
                Description = newsInput.Description,
                FacultyId = facultyId,
                PhotoFilePath= image,
                CreationDate=DateTime.Now
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