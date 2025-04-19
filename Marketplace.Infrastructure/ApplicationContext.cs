using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure;

public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +
                                     "Port=5432;" +
                                     "Database=marketplace;" +
                                     "Username=postgres;" +
                                     "Password=1");
            // Или использовать переменные окружения, если хочешь:
            // var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            // optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Пример конфигурации связей (если нужно):
        // modelBuilder.Entity<ProductCharacteristic>()
        //     .HasKey(pc => new { pc.ProductId, pc.CharacteristicId });
    }
}