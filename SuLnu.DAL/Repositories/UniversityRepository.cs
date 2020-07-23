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

        public University Get(string id)
        {
            return db.Universities.Find(id);
        }

        public void Create(University university)
        {
            db.Universities.Add(university);
        }

        public void Update(University university)
        {
            db.Entry(university).State = EntityState.Modified;
        }

        public IEnumerable<University> Find(Func<University, Boolean> predicate)
        {
            return db.Universities.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            University university = db.Universities.Find(id);
            if (university != null)
                db.Universities.Remove(university);
        }
    }
}
