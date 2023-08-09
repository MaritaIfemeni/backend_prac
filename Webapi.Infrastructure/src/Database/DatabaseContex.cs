using Microsoft.EntityFrameworkCore;
using Npgsql;
using Webapi.Domain.src.Entities;

namespace Webapi.Infrastructure.src.Database
{
    public class DatabaseContex : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<User> Users { get; set; }


        public DatabaseContex(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_config.GetConnectionString("Default"));
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}