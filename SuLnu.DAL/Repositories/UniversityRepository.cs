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
    class UniversityRepository : IRepository<University>
    {
        private SuLnuDbContext db;

        public UniversityRepository(SuLnuDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<University> GetAll()
        {
            return db.Universities;
        }

        public University Get(int id)
        {
            return db.Universities.Find(id);
        }

        public void Create(University answer)
        {
            db.Universities.Add(answer);
        }

        public void Update(University answer)
        {
            db.Entry(answer).State = EntityState.Modified;
        }

        public IEnumerable<University> Find(Func<University, Boolean> predicate)
        {
            return db.Universities.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            University answer = db.Universities.Find(id);
            if (answer != null)
                db.Universities.Remove(answer);
        }
    }
}
