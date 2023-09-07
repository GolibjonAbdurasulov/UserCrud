using Microsoft.EntityFrameworkCore;
using UserCRUD.Domain;

namespace UserCRUD.DataService;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string connectionString = "Host=localhost; Port=5432; Database=CRUD; username=postgres; password=3214";

        optionsBuilder
            .UseNpgsql(connectionString);
        
        base.OnConfiguring(optionsBuilder);
        
    }
}