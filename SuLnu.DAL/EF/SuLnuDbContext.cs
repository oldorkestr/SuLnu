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
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Documnet> Documnets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
    }
}
