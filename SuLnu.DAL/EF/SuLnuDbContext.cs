using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuLnu.DAL.Entities;

namespace SuLnu.DAL.EF
{
    public class SuLnuDbContext : IdentityDbContext<AppUser>
    {
        public SuLnuDbContext(DbContextOptions<SuLnuDbContext> options)
            : base(options)
        {
        }
    }
}
