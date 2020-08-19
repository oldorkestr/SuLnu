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
            return db.Documents;
        }

        public Document Get(string id)
        {
            return db.Documents.Find(id);
        }

        public void Create(Document document)
        {
            db.Documents.Add(document);
        }

        public void Update(Document document)
        {
            db.Entry(document).State = EntityState.Modified;
        }

        public IEnumerable<Document> Find(Func<Document, Boolean> predicate)
        {
            return db.Documents.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Document document = db.Documents.Find(id);
            if (document != null)
                db.Documents.Remove(document);
        }
    }
}
