using Microsoft.EntityFrameworkCore;
using Task_2.Entities;

namespace Task_2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options): base(options)
    { 
    }

    public DbSet<User> Users { get; set; } 
}
