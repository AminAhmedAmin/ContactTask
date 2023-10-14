using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ContactTask.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contact>().HasQueryFilter(x => !x.IsDeleted );

        }

       

    }
}
