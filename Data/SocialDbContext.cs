using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
    }
}
