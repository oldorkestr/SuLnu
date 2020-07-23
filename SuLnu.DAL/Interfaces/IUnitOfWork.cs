using SuLnu.DAL.Entities;
using System;

namespace SuLnu.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<University> Universities { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Document> Documents { get; }
        IRepository<Event> Events { get; }
        IRepository<News> News { get; }
        void Save();
    }
}
