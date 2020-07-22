using System;
using System.Collections.Generic;
using System.Text;
using SuLnu.DAL.EF;
using SuLnu.DAL.Entities;
using SuLnu.DAL.Interfaces;
using SuLnu.DAL.Repositories;

namespace SuLnu.DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SuLnuDbContext db;
        private UniversityRepository universityRepository;
        
        public EFUnitOfWork(SuLnuDbContext context)
        {
            db = context;
        }

        public IRepository<University> Universities
        {
            get
            {
                if (universityRepository == null)
                    universityRepository = new UniversityRepository(db);
                return universityRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
