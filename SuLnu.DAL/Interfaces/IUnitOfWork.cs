using System;

namespace SuLnu.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
