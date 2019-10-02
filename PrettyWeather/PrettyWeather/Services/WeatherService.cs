﻿using System;
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

        public static List<string> NORTH_AMERICA_CITIES = new List<string>() {
            "3530597", // Mexico City
            "5128581", // New York
            "5368361", // Los Angeles
            "6167865", // Toronto
            "4887398", // Chicago
            "4699066", // Houston
            "3553478", // Havana
            "6077243", // Montreal
            "3529612", // 
            "4560349" // Philadelphia
        };

        public static List<string> SOUTH_AMERICA_CITIES = new List<string>()
        {
            "3448439", // "Sao Paulo",
            "3936456", // "Lima",
            "3688689", // "Bogota",
            "3451190", // "Rio de Janeiro",
            "1687801", // "Santiago",
            "3646738", // "Caracas",
            "3435910", // "Buenos Aires",
            "3450554", // "Salvador",
            "3459342", // "Brasilia",
            "6320062" // "Fortaleza"

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

        //public async Task<WeatherRoot> GetWeatherAsync(string city, Units units = Units.Imperial)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var url = string.Format(WeatherCityUri, HttpUtility.UrlEncode(city), units.ToString().ToLower());
        //        Debug.WriteLine(url);
        //        var json = await client.GetStringAsync(url);
        //
        //        if (string.IsNullOrWhiteSpace(json))
        //            return null;
        //
        //        return DeserializeObject<WeatherRoot>(json);
        //    }
        //
        //}

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
                //Console.WriteLine($"@@@@@@ json: {json}");
                if (string.IsNullOrWhiteSpace(json))
                    return null;

                var result = DeserializeObject<CitiesWeatherRoot>(json);

                foreach( var c in result.CityList)
                Console.WriteLine($"@@@@@@@  {c.Name}, {c.CurrentWeather.Temp}");
                return result;
            }

        }
    }
}
