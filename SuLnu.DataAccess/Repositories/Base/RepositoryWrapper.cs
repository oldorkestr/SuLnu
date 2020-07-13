using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SuLnu.DataAccess.Interfaces.Base;
using SuLnu.DataAccess.Interfaces;

namespace SuLnu.DataAccess.Repositories.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SuLnuDBContext _suLnuDBContext;
        public void Save()
        {
            _suLnuDBContext.SaveChanges();
        }
    }
}
