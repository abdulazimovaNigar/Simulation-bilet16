using Bilet16Trainers.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet16Trainers.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
        
    }
}
