using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesAPI.Domain;

public class Course
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }  = string.Empty;

    [BsonElement("category")]
    public string Category { get; set; } = string.Empty;

    [BsonElement("blurb")]
    public string Blurb { get; set; } = string.Empty;

    [BsonElement("positionInCategory")]
    public int PositionInCategory { get; set; }
}
