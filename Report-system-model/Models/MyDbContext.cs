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

    public DbSet<AnalyticalFeature> AnalyticalFeatures { get; set; }
    public DbSet<BusinessProcess> BusinessProcesses { get; set; }
    public DbSet<FormationFrequency> FormationFrequencies { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportCode> ReportCodes { get; set; }
    public DbSet<ReportId> ReportIds { get; set; }
    public DbSet<ReportIndicator> ReportIndicators { get; set; }
    public DbSet<ReportTitle> ReportTitles { get; set; }
    public DbSet<Analytical> Analyticals { get; set; }
    public DbSet<Directory> Directories { get; set; }
    public DbSet<DirectoryAttributes> DirectoryAttributesEnumerable { get; set; }
    public DbSet<DirectoryProperties> DirectoryPropertiesEnumerable { get; set; }
    public DbSet<DirectoryPropertyHierarchyLevel> DirectoryPropertyHierarchyLevels { get; set; }
    public DbSet<DirectoryRegister> DirectoryRegisters { get; set; }
    public DbSet<EncodingLanguage> EncodingLanguages { get; set; }
    public DbSet<HierarchyLevel> HierarchyLevels { get; set; }
    public DbSet<KSSS> Kssses { get; set; }
    public DbSet<LevelIndicator> LevelIndicators { get; set; }
    public DbSet<LoadType> LoadTypes { get; set; }
    public DbSet<LocalCorporate> LocalCorporates { get; set; }
    public DbSet<NsiObj> NsiObjs { get; set; }
    public DbSet<ReleaseIndicatorSourceSystem> ReleaseIndicatorSourceSystems { get; set; }
    public DbSet<SourceTableInDW> SourceTableInDws { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "rsm666",
            Username = "postgres",
            Password = "postgres",
        };

        optionsBuilder.UseNpgsql(builder.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //дополнительные настройки моделей здесь, если необходимо
    }
}