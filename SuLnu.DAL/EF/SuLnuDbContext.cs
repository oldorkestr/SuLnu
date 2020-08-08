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
        public DbSet<Document> Documents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Faculty>().HasData(
                new Faculty[]
                {
                    new Faculty {Id=1, Name = "Applied mathematics and computer science" },
                    new Faculty {Id=2, Name = "Electronics" },
                    new Faculty { Id=3, Name = "Philology" },
                    new Faculty {  Id=4, Name = "Mechanics and Mathematics" }
                }

            );

            base.OnModelCreating(builder);
        }
    }
}
