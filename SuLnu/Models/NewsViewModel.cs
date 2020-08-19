using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuLnu.BLL.DTO;

namespace SuLnu.Models
{
    public class NewsViewModel
    {
        public string Tilte { get; set; }
        public string Description { get; set; }
        public string PhotoFilePath { get; set; }
        public List<NewsDTO> News { get; internal set; }
    }
}