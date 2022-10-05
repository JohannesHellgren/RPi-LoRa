using Webserver.Data;

namespace Webserver.Services 
{
    public interface IWeatherService
    {
        void SaveOrUpdate(Weather weather);

        Weather GetWeatherPoint(string WeatherId);

        List<Weather> GetWeather();

        string Delete(string weatherId);
    }
}
