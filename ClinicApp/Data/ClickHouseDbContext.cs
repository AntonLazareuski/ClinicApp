using ClickHouse.EntityFrameworkCore.Extensions;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Data
{
    public class ClickHouseDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public ClickHouseDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ClickHouseConnection");
            optionsBuilder.UseClickHouse(connectionString);
        }

        public DbSet<ClinicData> ClinicData { get; set; }
        public DbSet<ClinicListData> ClinicListData { get; set; }

        public DbSet<ClinicListItem> ClinicListItem { get; set; } 
    }
}
