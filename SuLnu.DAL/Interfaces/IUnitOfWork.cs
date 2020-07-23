using SuLnu.DAL.Entities;
using System;

namespace SuLnu.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<University> Universities { get; }

        void Save();
    }
}
