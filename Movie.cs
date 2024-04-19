using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace MongoFlix;

[Collection(Constants.MoviesCollectionName)]
public class Movie(string title, int year)
{
    public ObjectId Id { get; private set; }
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
    public string? Plot { get; set; }
    public string? Rated { get; set; }
    public IList<string> Genres { get; set; } = new List<string>();
    public Awards? Awards { get; set; }
    // public bool? TheBookWasBetter { get; set; }
    
    public override string ToString() => $"{Title} ({Year}) [{string.Join(", ", Genres)}]{Environment.NewLine}\t{Awards?.Text}";
}