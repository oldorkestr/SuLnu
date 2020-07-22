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
        private IUserRepository _user;
        private IEducationRepository _education;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_suLnuDBContext);
                }

                return _user;
            }
        }
        public IEducationRepository Education 
        {
            get
            {
                if (_education == null)
                {
                    _education = new EducationRepository(_suLnuDBContext);
                }

                return _education;
            }
        }
        public RepositoryWrapper(SuLnuDBContext suLnuDBContext)
        {
            _suLnuDBContext = suLnuDBContext;
        }
        public void Save()
        {
            _suLnuDBContext.SaveChanges();
        }
    }
}
