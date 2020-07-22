using SuLnu.DataAccess.Repositories.Base;
using SuLnu.DataAccess.Entities.User;

namespace SuLnu.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SuLnuDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
