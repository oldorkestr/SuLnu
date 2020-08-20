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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<University>().HasData(
               new University[]
               {
                    new University {Id=1, Name = "LNU" },
               }
           );
            builder.Entity<Faculty>().HasData(
                new Faculty[]
                {
                       new Faculty {Id=1, Name = "Applied mathematics and computer science", UniversityId=1 },
                       new Faculty {Id=2, Name = "Electronics" ,UniversityId=1},
                       new Faculty { Id=3, Name = "Philology",UniversityId=1 },
                       new Faculty {  Id=4, Name = "Mechanics and Mathematics",UniversityId=1 }
                }
            );
            base.OnModelCreating(builder);
        }
    }
}
