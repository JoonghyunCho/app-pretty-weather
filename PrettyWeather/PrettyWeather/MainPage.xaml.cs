using PrettyWeather.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace PrettyWeather
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    _ = (BindingContext as PrettyWeather.ViewModel.WeatherViewModel).GetGroupedWeatherAsync();
            //});


            //Console.WriteLine("###### vm?");
            //if (vm.Cities.Count > 0)
            //{
            //    Console.WriteLine("###### Update Selected City to :");
            //    Console.WriteLine("###### Update Selected City to :" + vm.Cities[0]);
            //    vm.SelectedCity = vm.Cities[0];
            //}
            //Console.WriteLine("###### vm? 2");
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            _ = (BindingContext as PrettyWeather.ViewModel.WeatherViewModel).GetGroupedWeatherAsync();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("###### CollectionView_SelectionChanged: " + (e.CurrentSelection[0] as City).Name);
        }
    }
}