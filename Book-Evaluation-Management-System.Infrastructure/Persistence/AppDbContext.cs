using Book_Evaluation_Management_System.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Evaluation_Management_System.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}