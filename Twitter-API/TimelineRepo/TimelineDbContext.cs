using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineRepo
{
    public class TimelineDbContext : DbContext
    {
        public TimelineDbContext(DbContextOptions<TimelineDbContext> options, ServiceLifetime service) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Timeline> Timelines { get; set; }
    }
}
