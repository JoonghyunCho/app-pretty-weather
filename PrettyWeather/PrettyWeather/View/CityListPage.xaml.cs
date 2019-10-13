using PrettyWeather.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrettyWeather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CityListPage : ContentPage
    {
        public CityListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() =>
            {
                collection.Focus();
            });
        }

        private void CityListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Console.WriteLine($"######### 222 Selection Changed: {(e.CurrentSelection[0] as City).Name}");
            var newCity = e.CurrentSelection[0] as City;
            Device.BeginInvokeOnMainThread(()=>
            {
                (this.BindingContext as ViewModel.WeatherViewModel).SelectedCityItem = newCity;
            });
            Shell.Current.GoToAsync("//prettyWeather").Wait();
        }
    }
}