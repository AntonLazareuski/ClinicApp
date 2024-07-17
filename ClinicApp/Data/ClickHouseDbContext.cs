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
            base.OnConfiguring(optionsBuilder); 

            var connectionString = _configuration.GetConnectionString("ClickHouseConnection");
            optionsBuilder.UseClickHouse(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<ClinicData>();

            entityTypeBuilder.Property(e => e.ClinicId).HasColumnName("Clinic_id");
            entityTypeBuilder.Property(e => e.ClinicName).HasColumnName("Clinic_name");
            entityTypeBuilder.Property(e => e.Timestamp).HasColumnName("Timestamp");
            entityTypeBuilder.Property(e => e.TariffName).HasColumnName("Tariff_name");
            entityTypeBuilder.Property(e => e.StageId).HasColumnName("Stage_id");
            entityTypeBuilder.Property(e => e.AccountManager).HasColumnName("Account_manager");
            entityTypeBuilder.Property(e => e.AccountManagerPhoto).HasColumnName("Account_manager_photo");

            entityTypeBuilder.HasNoKey();

            entityTypeBuilder.ToTable("default");


        }

        public DbSet<ClinicData> ClinicData { get; set; }
        /*public DbSet<ClinicListData> ClinicListData { get; set; }*//*

        public DbSet<ClinicListItem> ClinicListItem { get; set; } */
    }
}
