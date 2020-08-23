using Microsoft.AspNetCore.Identity;
using SuLnu.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuLnu.BLL.Interfaces
{
    public interface INewsService
    {
        public IEnumerable<NewsDTO> GetAll();
        public void CreateNews(NewsDTO newsDTO);
        void UpdateImage(int userId, string imageSrc);

    }
}
