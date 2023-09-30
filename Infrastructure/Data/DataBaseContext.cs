using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataBaseContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}