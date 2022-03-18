using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }

    public DbSet<Suburb> Suburbs { get; set; }

    public DbSet<Category> Categories { get; set; }
}
