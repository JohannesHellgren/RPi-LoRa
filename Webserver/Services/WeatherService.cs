using MongoDB.Driver;
using Webserver.Data;

namespace Webserver.Services 
{
    public class WeatherService : IWeatherService 
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Weather> _weatherTable = null;

        public WeatherService() 
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("garage");
            _weatherTable = _database.GetCollection<Weather>("weather");
        }

        public string Delete(string weatherId)
        {
            _weatherTable.DeleteOne(x=>x.Id==weatherId);
            return "Deleted";
        }

        public List<Weather> GetWeather() 
        {
            return _weatherTable.Find(FilterDefinition<Weather>.Empty).ToList();
        }

        public Weather GetWeatherPoint(string weatherId) 
        {
            return _weatherTable.Find(x => x.Id == weatherId).FirstOrDefault();
        }

        public void SaveOrUpdate(Weather weather) 
        {
            var weatherObj = _weatherTable.Find(x=>x.Id == weather.Id).FirstOrDefault();

            if (weatherObj == null) {
                weather.timestamp = DateTime.UtcNow;
                _weatherTable.InsertOne(weather);
            }
            else {
                _weatherTable.ReplaceOne(x => x.Id == weather.Id, weather);
            }
        }
    }
}
