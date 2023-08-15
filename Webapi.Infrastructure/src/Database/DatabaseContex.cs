using Microsoft.EntityFrameworkCore;
using Npgsql;
using Webapi.Domain.src.Entities;

namespace Webapi.Infrastructure.src.Database
{
    public class DatabaseContex : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public  DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Image> Images { get; set; }

        public DatabaseContex(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        static DatabaseContex()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_config.GetConnectionString("Default"));
            builder.MapEnum<UserRole>();
            builder.MapEnum<OrderStatus>();
            optionsBuilder.AddInterceptors(new TimeStampInterceptor());
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresEnum<UserRole>();
            modelBuilder.HasPostgresEnum<OrderStatus>();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<OrderDetail>().HasKey("OrderId", "ProductId");  //Add this line for the productdetail primary keys
            
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages) // A product has many images
                .WithOne()                     // An image belongs to one product
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
