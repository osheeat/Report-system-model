using Microsoft.EntityFrameworkCore;
using Report_system_model.DBModels;
using Npgsql;
using ValueType = Report_system_model.DBModels.ValueType;

namespace Report_system_model;

public class MyDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<CurrencyUnit> CurrencyUnits { get; set; }
    public DbSet<DataStatus> DataStatuss { get; set; }
    public DbSet<FormationMethodology> FormationMethodologies { get; set; }
    public DbSet<IndicatorGenerationMethod> IndicatorGenerationMethods { get; set; }
    public DbSet<IndicatorSourceSystem> IndicatorSourceSystems { get; set; }
    public DbSet<Keyfigure> Keyfigures { get; set; }
    public DbSet<KeyfigureCategory> KeyfigureCategories { get; set; }
    public DbSet<LoadTime> LoadTimes { get; set; }
    public DbSet<MethodOfObtaining> MethodsOfObtaining { get; set; }
    public DbSet<Release> Releases { get; set; }
    public DbSet<ReportUsageIndicator> ReportUsageIndicators { get; set; }
    public DbSet<SourceSystem> SourceSystems { get; set; }
    public DbSet<UploadDeadline> UploadDeadlines { get; set; }
    public DbSet<ValueType> ValueTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "rsmDB",
            Username = "postgres",
            Password = "123321",
        };

        optionsBuilder.UseNpgsql(builder.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Добавьте дополнительные настройки моделей здесь, если необходимо
    }
}