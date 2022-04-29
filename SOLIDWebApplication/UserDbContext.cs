using Microsoft.EntityFrameworkCore;

namespace SOLIDWebApplication
{
    internal sealed class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            optionsBuilder
            .UseNpgsql("Host = 192.168.1.72; Database = GeekBrains; Username = postgres; Password = qwe123; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Ignore(x => x.Comment);
        }
    }
}
