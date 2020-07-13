using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SuLnu.DataAccess
{
    public class SuLnuDBContext : IdentityDbContext
    {
        public SuLnuDBContext(DbContextOptions<SuLnuDBContext> options)
            : base(options)
        {

        }
    }
}
