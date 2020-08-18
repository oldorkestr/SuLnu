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
        public DbSet<Document> Documnets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Faculty>().HasData(
        //        new Faculty[]
        //        {
        //            new Faculty {Id="a", Name = "Applied mathematics and computer science" },
        //            new Faculty {Id="b", Name = "Electronics" },
        //            new Faculty { Id="c", Name = "Philology" },
        //            new Faculty {  Id="d", Name = "Mechanics and Mathematics" }
        //        }

        //    );

        //    base.OnModelCreating(builder);
        //}
    }
}
