using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RegistrationApi.Models;

namespace RegistrationApi.Domain;

public class Reservation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("status")]
    public RegistrationStatus Status { get; set; }

    [BsonElement("request")]
    public RegistrationInfo Request { get; set; } = new();

}

public class RegistrationInfo
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("dateOfCourse")]
    public DateTime DateOfCourse { get; set; }

    [BsonElement("course")]
    public string Course { get; set; } = string.Empty;
}
