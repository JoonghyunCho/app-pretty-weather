﻿using PrettyWeather.Model;
using PrettyWeather.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrettyWeather.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        //public int Temp { get; set; }
        public WeatherViewModel()
        {
            _selectedCity = new City();
            _selectedCity.Name = string.Empty;
        }

        public WeatherViewModel(int temp)
        {
            _selectedCity = new City();
            _selectedCity.Name = string.Empty;
            Temp = temp;
        }

        private int _temp = 73;
        private string _weatherURL = "";
        private string _weatherURLFormat = "http://openweathermap.org/img/wn/{0}@2x.png";
        private string _description;
        //private WeatherForecastRoot _forecast;
        //private ICommand _reloadCommand;
        //private ICommand _openFlyoutCommand;
        //private ICommand _navToOtherPage;

        private bool _isBusy = false;

        public string Date
        {
            get
            {
                return DateTime.Today.ToString("dddd, dd MMMM");
            }
        }

        ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;

                //OnPropertyChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cities"));
            }
        }

        public int Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                //OnPropertyChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Temp"));
            }
        }

        City _selectedCity;
        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                if (_selectedCity.Name != string.Empty)
                {
                    Temp = _selectedCity.CurrentWeather.Temp;
                    WeatherURL = string.Format(_weatherURLFormat, _selectedCity.Weather[0].Icon);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCity"));
            }
        }

        public string WeatherURL
        {
            get
            {
                return _weatherURL;
            }
            set
            {
                _weatherURL = value;
                Console.WriteLine($"########### Weather URL: {_weatherURL}");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WeatherURL"));
            }
        }

        public string Description
        {
            get {
                if (SelectedCity == null)
                    return string.Empty;
                else
                    return SelectedCity?.Weather[0].Icon + SelectedCity?.Weather[0].Description; }
            //set
            //{
            //    _description = SelectedCity.Weather[0].Icon + SelectedCity.Weather[0].Description;
            //    //OnPropertyChanged();
            //
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCity"));
            //}
        }

        //public WeatherForecastRoot Forecast
        //{
        //    get { return _forecast; }
        //    set
        //    {
        //        _forecast = value;
        //        //OnPropertyChanged();
        //    }
        //}

        bool _useCelsius;
        public bool UseCelsius
        {
            get => _useCelsius;
            set
            {
                //if (SetProperty(ref useCelsius, value))
                //{
                //    BackgroundColorConverter.UseCelcius = UseCelsius;
                //    //OnPropertyChanged(nameof(Temp));
                //}
                _useCelsius = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UseCelsius"));
            }
        }

        List<Continent> _continents;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Continent> Continents
        {
            get { return _continents; }
            set
            {
                _continents = value;
                //OnPropertyChanged();
            }
        }

        public string CurrentConditionsIcon { get; set; }
        public bool IsBusy
        {
            get {
                return _isBusy;
            }
            private set
            {
                _isBusy = value;
            }
        }

        //public async Task GetWeatherAsync()
        //{
        //    if (IsBusy)
        //        return;
        //
        //    IsBusy = true;
        //    try
        //    {
        //        WeatherRoot weatherRoot = null;
        //        var units = _useCelsius ? Units.Metric : Units.Imperial;
        //        weatherRoot = await WeatherService.Instance.GetWeatherAsync(location.Trim(), units);
        //        //Forecast = await WeatherService.Instance.GetForecast(weatherRoot.CityId, units);
        //        var unit = _useCelsius ? "C" : "F";
        //        //Temp = $"{weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
        //        Temp = Convert.ToInt32(weatherRoot?.MainWeather?.Temperature);
        //        Condition = $"{weatherRoot.Name}: {weatherRoot?.Weather?[0]?.Description ?? string.Empty}";
        //        CurrentConditionsIcon = weatherRoot?.Weather?[0].Icon;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        //Temp = "Unable to get Weather";
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public async Task GetFlatWeatherAsync(List<string> cities)
        //{
        //    if (IsBusy)
        //        return;
        //
        //    IsBusy = true;
        //    try
        //    {
        //        CitiesWeatherRoot payload = null;
        //        var units = useCelsius ? Units.Metric : Units.Imperial;
        //        payload = await WeatherService.Instance.GetWeatherAsync(cities, units);
        //
        //        Cities = new ObservableCollection<City>(payload.CityList);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        //Temp = "Unable to get Weather";
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public async Task GetGroupedWeatherAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                List<string> allCities = WeatherService.WORLD_CITIES;

                //await GetFlatWeatherAsync(allCities);
                CitiesWeatherRoot payload = null;
                var units = Units.Imperial;//_useCelsius ? Units.Metric : Units.Imperial;
                payload = await WeatherService.Instance.GetWeatherAsync(allCities, units);
                _cities = new ObservableCollection<City>(payload.CityList);
                //Debug.WriteLine("@@@@@@@@@" + _cities.ToArray());
                //_continents = new List<Continent>();
                //_continents.Add(
                //    new Continent(name:"North America", cities: GetCitiesIn(_cities, WeatherService.NORTH_AMERICA_CITIES))                    
                //);

                //_continents.Add(
                //    new Continent(name:"South America", cities: GetCitiesIn(_cities, WeatherService.SOUTH_AMERICA_CITIES))
                //);

                //OnPropertyChanged(nameof(Continents));

                //OnPropertyChanged(nameof(Cities));
                PropertyChanged(this, new PropertyChangedEventArgs("Cities"));

                if (_cities.Count > 0)
                    SelectedCity = _cities[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //Temp = "Unable to get Weather";
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private List<City> GetCitiesIn(List<City> cities, List<string> cityIds)
        //{
        //    return cities.Where(x => cityIds.Contains(x.Id.ToString())).ToList();
        //}
    }
}
