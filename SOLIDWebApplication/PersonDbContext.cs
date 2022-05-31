using Microsoft.EntityFrameworkCore;
using SOLIDWebApplication.Models;

namespace SOLIDWebApplication
{
    public sealed class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            optionsBuilder
            .UseNpgsql("Host = 192.168.1.72; Database = GeekBrains; Username = postgres; Password = qwe123;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>();
        }
    }
}
