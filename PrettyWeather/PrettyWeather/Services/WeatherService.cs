using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using PrettyWeather.Model;
using static Newtonsoft.Json.JsonConvert;
using System.Diagnostics;

namespace PrettyWeather.Services
{
    public enum Units
    {
        Imperial,
        Metric
    }

    public class WeatherService
    {
        const string WeatherCitiesUri = "http://api.openweathermap.org/data/2.5/group?id={0}&units={1}&appid=cd6084286640ac2ef0b60b4eb006a477";

        public static List<string> WORLD_CITIES = new List<string>() {
            "1835847", // Seoul
            "5809844", // Seattle
            "5391959", // San Francisco
            "5392171", // San Jose
            "5128581", // New York
            "5368361", // Los Angeles
            "3530597", // Mexico City
            "6167865", // Toronto
            "4887398", // Chicago
            "4699066", // Houston
            "3448439", // "Sao Paulo",
            "3451190", // "Rio de Janeiro",
        };

        private static WeatherService _instance;

        public static WeatherService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherService();

                return _instance;
            }
        }

        //public async Task<WeatherRoot> GetWeatherAsync(double latitude, double longitude, Units units = Units.Imperial)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var url = string.Format(WeatherCoordinatesUri, latitude, longitude, units.ToString().ToLower());
        //        var json = await client.GetStringAsync(url);
        //
        //        if (string.IsNullOrWhiteSpace(json))
        //            return null;
        //
        //        return DeserializeObject<WeatherRoot>(json);
        //    }
        //
        //}

        ///public async Task<WeatherRoot> GetWeatherAsync(string city, Units units = Units.Imperial)
        ///{
        ///    using (var client = new HttpClient())
        ///    {
        ///        var url = string.Format(WeatherCityUri, HttpUtility.UrlEncode(city), units.ToString().ToLower());
        ///        Debug.WriteLine(url);
        ///        var json = await client.GetStringAsync(url);
        ///
        ///        if (string.IsNullOrWhiteSpace(json))
        ///            return null;
        ///
        ///        return DeserializeObject<WeatherRoot>(json);
        ///    }
        ///
        ///}

        //public async Task<WeatherForecastRoot> GetForecast(int id, Units units = Units.Imperial)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var url = string.Format(ForecaseUri, id, units.ToString().ToLower());
        //        var json = await client.GetStringAsync(url);
        //
        //        if (string.IsNullOrWhiteSpace(json))
        //            return null;
        //
        //        return DeserializeObject<WeatherForecastRoot>(json);
        //    }
        //
        //}

        public async Task<CitiesWeatherRoot> GetWeatherAsync(List<string> cities, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCitiesUri, string.Join(",", cities), units.ToString().ToLower());
                //Console.WriteLine($"@@@@@@ url: {url}");
                var json = await client.GetStringAsync(url);
                //Console.WriteLine($"@@@@@@### json: {json}");
                if (string.IsNullOrWhiteSpace(json))
                    return null;

                var result = DeserializeObject<CitiesWeatherRoot>(json);

                //foreach( var c in result.CityList)
                //{
                //    Console.WriteLine($"########## {c.Weather[0].Description}");
                //    Console.WriteLine($"@@@@@@@  {c.Name}, {c.CurrentWeather.Temp}");
                //}
                return result;
            }

        }
    }
}
