using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Metadata.Conventions;

namespace MongoFlix;

public class MoviesDbContext : DbContext
{
    // public DbSet<Movie> Movies { get; init; }
    
    public static MoviesDbContext Create(IMongoDatabase database)
    {
        var options = new DbContextOptionsBuilder<MoviesDbContext>()
            // .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            #region Logging
            //.LogTo(Console.WriteLine)
            // .EnableSensitiveDataLogging()
            #endregion
            .Options;
        return new MoviesDbContext(options);
    }
    
    private MoviesDbContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    // {
        // configurationBuilder.Conventions.Add(serviceProvider =>
            // new CamelCaseElementNameConvention(serviceProvider
                // .GetRequiredService<ProviderConventionSetBuilderDependencies>()));
    // }
}