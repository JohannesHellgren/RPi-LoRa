using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webserver.Data 
{
    public class Weather 
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public BsonDateTime timestamp { get; set; }

        public int temperature { get; set; }

        public int humidity { get; set; }
    }
}
