using Microsoft.EntityFrameworkCore;
using Training.DataContext;
using Training.Entities;

public class SalesDbContext : DbContext
{
    public DbSet<Region> Regions { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<SalesRecord> SalesRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=192.168.50.2:5433;Database=Sale;Username=postgres;Password=postgresPsw")
            .AddInterceptors(new CommandTimeOutInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesRecord>()
            .HasOne(sr => sr.Country)
            .WithMany(c => c.SalesRecords)
            .HasForeignKey(sr => sr.CountryID);

        modelBuilder.Entity<Region>()
            .HasMany(r => r.Countries)
            .WithOne(c => c.Region)
            .HasForeignKey(c => c.RegionID)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Country>()
            .HasMany(c => c.SalesRecords)
            .WithOne(sr => sr.Country)
            .HasForeignKey(sr => sr.CountryID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SalesRecord>()
            .HasIndex(sr => sr.OrderDate)
            .HasDatabaseName("IX_SalesRecords_OrderDate");
    }
}