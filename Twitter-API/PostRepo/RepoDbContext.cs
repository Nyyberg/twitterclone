using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PostRepo
{
    public class RepoDbContext : DbContext
    {
        public RepoDbContext(DbContextOptions<RepoDbContext> options, ServiceLifetime service) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(p => p.postID);

        }

        public DbSet<Post> posts { get; set; }

       
    }
}
