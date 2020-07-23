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
    class DocumentRepository : IRepository<Documnet>
    {
        private SuLnuDbContext db;

        public DocumentRepository(SuLnuDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Documnet> GetAll()
        {
            return db.Documnets;
        }

        public Documnet Get(string id)
        {
            return db.Documnets.Find(id);
        }

        public void Create(Documnet document)
        {
            db.Documnets.Add(document);
        }

        public void Update(Documnet document)
        {
            db.Entry(document).State = EntityState.Modified;
        }

        public IEnumerable<Documnet> Find(Func<Documnet, Boolean> predicate)
        {
            return db.Documnets.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Documnet document = db.Documnets.Find(id);
            if (document != null)
                db.Documnets.Remove(document);
        }
    }
}
