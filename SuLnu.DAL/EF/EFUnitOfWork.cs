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
        private FacultyRepository facultyRepository;
        private DocumentRepository documentRepository;
        private EventRepository eventRepository;
        private NewsRepository newsRepository;

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

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultyRepository(db);
                return facultyRepository;
            }
        }

        public IRepository<Documnet> Documents
        {
            get
            {
                if (documentRepository == null)
                    documentRepository = new DocumentRepository(db);
                return documentRepository;
            }
        }

        public IRepository<Event> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepository(db);
                return eventRepository;
            }
        }

        public IRepository<News> News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;
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
