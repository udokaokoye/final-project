using Microsoft.EntityFrameworkCore;
namespace Final_Project.Models
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> Team { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Library> Library { get; set; }




    }
}

