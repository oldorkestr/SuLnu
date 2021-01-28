using System;
using System.Collections.Generic;
using System.Text;
using SuLnu.DAL.Entities;
using SuLnu.DAL.EF;
using SuLnu.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SuLnu.DAL.Repositories
{
    class NewsRepository : IRepository<News>
    {
        private SuLnuDbContext db;

        public NewsRepository(SuLnuDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<News> GetAll()
        {
            return db.News;
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public void Create(News news)
        {
            db.News.Add(news);
        }

        public void Update(News news)
        {
            db.Entry(news).State = EntityState.Modified;
        }

        public IEnumerable<News> Find(Func<News, Boolean> predicate)
        {
            return db.News.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            News news = db.News.Find(id);
            if (news != null)
                db.News.Remove(news);
        }
    }
}
