using System;
using Microsoft.EntityFrameworkCore;

namespace Application.Models
{
    public class AppSystemContext : DbContext
    {
        public AppSystemContext(DbContextOptions<AppSystemContext> options) : base(options)
        {
        }

        public DbSet<AppProfile> AppProfiles { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
}