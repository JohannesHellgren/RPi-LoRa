using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webserver.Data 
{
    public class Weather 
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public DateTime Timestamp { get; set; }

        public string Temperature { get; set; }

        public string Humidity { get; set; }
    }
}
