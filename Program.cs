using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoFlix;

var client = new MongoClient();
var database = client.GetDatabase(Constants.MongoFlixDatabaseName);
await EnsureIndexesAsync(database);
await CleanSampleDataAsync(database);

using var db = MoviesDbContext.Create(database);
var moviesQuery = db.Movies.Where(m => m.Genres.Contains("Comedy") && m.Title.StartsWith("A")).OrderByDescending(m => m.Year);
foreach (var movie in moviesQuery.Take(5))
{
    Console.WriteLine(movie);
    var reviews = db.Reviews.Where(r => r.MovieId == movie.Id).OrderByDescending(r => r.Date);
    foreach (var review in reviews)
    {
        Console.WriteLine($"\t{review}");
    }
}

var newMovie = new Movie(ObjectId.Empty, "MongoDB: The Movie", Faker.Lorem.Paragraph(), 2024, "A", ["Documentary"], true);
db.Add(newMovie);
await db.SaveChangesAsync();

newMovie.Year = 2023;
newMovie.Genres.Add("True Story");
newMovie.Awards = new Awards(42, 42, "42 wins.");
await db.SaveChangesAsync();

db.Remove(newMovie);
await db.SaveChangesAsync();

async Task EnsureIndexesAsync(IMongoDatabase database)
{
    var convention = new CamelCaseElementNameConvention();
    ConventionRegistry.Register("camelCase", new ConventionPack {convention}, _ => true);
    var moviesIndex = new CreateIndexModel<Movie>(Builders<Movie>.IndexKeys
                                .Ascending(x => x.Title)
                                .Ascending(x => x.Genres));
    await database.GetCollection<Movie>(Constants.MoviesCollectionName).Indexes.CreateOneAsync(moviesIndex);

    var reviewsIndex = new CreateIndexModel<Review>(Builders<Review>.IndexKeys
                                .Ascending(x => x.MovieId)
                                .Descending(x => x.Date));
    await database.GetCollection<Review>(Constants.ReviewsCollectionName).Indexes.CreateOneAsync(reviewsIndex);
}

async Task CleanSampleDataAsync(IMongoDatabase database)
{
    await database.GetCollection<Movie>(Constants.MoviesCollectionName).DeleteManyAsync(m => m.IsTestData == true);
}