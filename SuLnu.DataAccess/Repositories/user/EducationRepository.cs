using SuLnu.DataAccess.Repositories.Base;
using SuLnu.DataAccess.Entities.User;

namespace SuLnu.DataAccess
{
    public class EducationRepository : RepositoryBase<Education>, IEducationRepository
    {
        public EducationRepository(SuLnuDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
