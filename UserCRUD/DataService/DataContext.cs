using Microsoft.EntityFrameworkCore;
using UserCRUD.Domain;

namespace UserCRUD.DataService;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string connectionString = "Host=localhost; Port=5432; Database=c; username=postgres; password=zuxriddin25";

        optionsBuilder
            .UseNpgsql(connectionString);
        
        base.OnConfiguring(optionsBuilder);
        
    }
}