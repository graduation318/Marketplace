using Marketplace.Data;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Migrations;

public class ApplicationContext:DbContext
{ 
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    /*
public ApplicationContext(DbContextOptions<ApplicationContext> options)
{

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
}
*/
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=marketplace;Username=postgres;Password=1");

        /*var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);*/
       
        /*optionsBuilder.UseNpgsql(_config.GetSection("DatabaseConfig")["pg_db"]);*/
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCharacteristic>()
            .HasKey(pc => new { pc.ProductId, pc.CharacteristicId });

        base.OnModelCreating(modelBuilder);
    }
}