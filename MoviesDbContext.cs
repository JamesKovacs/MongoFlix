using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Metadata.Conventions;

namespace MongoFlix;

public class MoviesDbContext : DbContext
{
    public DbSet<Movie> Movies { get; init; }
    
    private MoviesDbContext(DbContextOptions options) : base(options)
    {
    }

    public static MoviesDbContext Create(IMongoDatabase database)
    {
        var options = new DbContextOptionsBuilder<MoviesDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            //.LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging()
            .Options;
        return new MoviesDbContext(options);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(serviceProvider =>
            new CamelCaseElementNameConvention(serviceProvider
                .GetRequiredService<ProviderConventionSetBuilderDependencies>()));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}