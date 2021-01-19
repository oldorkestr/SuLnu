using SuLnu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SuLnu.Models
{
    public class PagedViewModel
    {
        public IEnumerable<NewsShortViewModel> News { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}