using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuLnu.DataAccess.Entities.User;

namespace SuLnu.DataAccess
{
    public class SuLnuDBContext : IdentityDbContext
    {
        public SuLnuDBContext(DbContextOptions<SuLnuDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Education> Educations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Education>()
                .HasKey(x => x.ID);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Education)
                .WithMany(x => x.Users);
        }
    } 
}
