using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Gov.Import.Data;
public class EntityContext : DbContext
{
    private readonly IConfiguration config;

    public DbSet<FapData> Faps { get; set; }

    public EntityContext(DbContextOptions<EntityContext> options, IConfiguration config)
        : base(options)
    {
        this.config = config;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(config.GetConnectionString(nameof(EntityContext)));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EntityContext>
{
    public EntityContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Gov;User Id=postgres;Password=root");
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        return new EntityContext(optionsBuilder.Options, config);
    }
}
