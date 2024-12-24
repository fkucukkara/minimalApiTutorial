using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class SocialDbContext(DbContextOptions<SocialDbContext> options) : DbContext(options)
{
    public DbSet<Post>? Posts { get; set; }
}