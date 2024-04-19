using System.Text;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace MongoFlix;

[Collection(Constants.ReviewsCollectionName)]
public record Review(ObjectId Id, string Name, string Email, ObjectId MovieId, string Text, DateTime Date)
{
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"{Name} ({Email}: {Text}");
        return true;
    }
}