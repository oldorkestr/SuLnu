using SuLnu.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuLnu.BLL.Interfaces
{
    public interface INewsService
    {
        public IEnumerable<NewsDTO> GetAll();
        public void CreateNews(NewsDTO newsDTO);
    }
}
