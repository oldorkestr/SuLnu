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
    class DocumentRepository : IRepository<Document>
    {
        private SuLnuDbContext db;

        public DocumentRepository(SuLnuDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Document> GetAll()
        {
            return db.Documnets;
        }

        public Document Get(string id)
        {
            return db.Documnets.Find(id);
        }

        public void Create(Document document)
        {
            db.Documnets.Add(document);
        }

        public void Update(Document document)
        {
            db.Entry(document).State = EntityState.Modified;
        }

        public IEnumerable<Document> Find(Func<Document, Boolean> predicate)
        {
            return db.Documnets.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Document document = db.Documnets.Find(id);
            if (document != null)
                db.Documnets.Remove(document);
        }
    }
}
