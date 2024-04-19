using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace MongoFlix;

[Collection(Constants.MoviesCollectionName)]
public class Movie(ObjectId id, string title, string? plot, int year, string? rated, IList<string> genres, bool? isTestData)
{
    public override string ToString() => $"{Title} ({Year}) [{string.Join(", ", Genres)}]{Environment.NewLine}\t{Awards?.Text}";

    public ObjectId Id { get; init; } = id;
    public string Title { get; set; } = title;
    public string? Plot { get; set; } = plot;
    public int Year { get; set; } = year;
    public string? Rated { get; set; } = rated;
    public IList<string> Genres { get; set; } = genres;
    public Awards? Awards { get; set; }
    public bool? IsTestData { get; set; } = isTestData;
}