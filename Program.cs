using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoFlix;

var client = new MongoClient();
var database = client.GetDatabase(Constants.MongoFlixDatabaseName);

#region Demos
// using var db = MoviesDbContext.Create(database);
// var moviesQuery = db.Movies
//     .Where(m => m.Genres.Contains("Comedy")
//                 && m.Title.StartsWith("A"))
//     .OrderByDescending(m => m.Year);
// foreach (var movie in moviesQuery.Take(5))
// {
//     Console.WriteLine(movie);
// }

// var newMovie = new Movie("MongoDB: The Movie", 2023)
// {
//     Plot = "A plucky little database revolutionizes software development.",
//     Rated = "A",
//     Genres = ["Documentary"],
//     TheBookWasBetter = true
// };
// db.Add(newMovie);
// await db.SaveChangesAsync();
//
// newMovie.Year = 2024;
// newMovie.Genres.Add("True Story");
// newMovie.Awards = new Awards(42, 42, "42 wins.");
// await db.SaveChangesAsync();
//
// db.Remove(newMovie);
// await db.SaveChangesAsync();
//
// await EnsureIndexesAsync(database);
// async Task EnsureIndexesAsync(IMongoDatabase database)
// {
//     var convention = new CamelCaseElementNameConvention();
//     ConventionRegistry.Register("camelCase", new ConventionPack {convention}, _ => true);
//     var moviesIndex = new CreateIndexModel<Movie>(Builders<Movie>.IndexKeys
//                                 .Ascending(x => x.Title)
//                                 .Ascending(x => x.Genres));
//     await database.GetCollection<Movie>(Constants.MoviesCollectionName).Indexes.CreateOneAsync(moviesIndex);
// }
#endregion