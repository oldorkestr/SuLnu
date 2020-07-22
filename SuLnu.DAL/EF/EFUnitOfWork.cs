using System;
using System.Collections.Generic;
using System.Text;
using SuLnu.DAL.EF;
using SuLnu.DAL.Interfaces;

namespace SuLnu.DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SuLnuDbContext db;
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
