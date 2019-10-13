using PrettyWeather.Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrettyWeather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrettyWeatherPage : ContentPage
    {
        public PrettyWeatherPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() =>
            {
                if (!string.IsNullOrEmpty((collection.SelectedItem as City).Name))
                {
                    Console.WriteLine($"### 11111111111111 Scroll to {(this.BindingContext as ViewModel.WeatherViewModel).SelectedItemIndex}");
                    collection.ScrollTo((this.BindingContext as ViewModel.WeatherViewModel).SelectedItemIndex, -1, ScrollToPosition.Center, false);
                }
                else
                {
                    collection.Focus();
                }
            });
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("### SelectionChanged 1: " + (e.CurrentSelection[0] as City).Name);
            if (!string.IsNullOrEmpty((collection.SelectedItem as City).Name))
            {
                Device.BeginInvokeOnMainThread(()=>
                {
                    Console.WriteLine("#### Scroll TO 22222222222222222");
                    collection.ScrollTo((this.BindingContext as ViewModel.WeatherViewModel).SelectedItemIndex, -1, ScrollToPosition.Center, true);
                });
            }

            var city = e.CurrentSelection[0] as City;
            if (city.Name.Equals("footer"))
            {
                Shell.Current.GoToAsync("//cityListPage").Wait();
            }
        }

        private void Label_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == Label.FormattedTextProperty.PropertyName)
            {
                var label = sender as Label;
                if(label.FormattedText.ToString().StartsWith((this.BindingContext as ViewModel.WeatherViewModel).SelectedCity.Name))
                {
                    Console.WriteLine($"########## {label.GetHashCode()}  Label.Text: {label.FormattedText} is starts with {(this.BindingContext as ViewModel.WeatherViewModel).SelectedCity.Name}");
                    //Console.WriteLine("#### Scroll TO : " + (collection.BindingContext as ViewModel.WeatherViewModel).SelectedItemIndex);

                    //collection.ScrollTo((collection.BindingContext as ViewModel.WeatherViewModel).SelectedItemIndex, -1, ScrollToPosition.Center, true);
                    Device.BeginInvokeOnMainThread(()=>
                    {
                        //    Device.StartTimer(TimeSpan.FromSeconds(3), () => {
                        (label.Parent as Xamarin.Forms.Grid).Children[0].Focus();
                    //    return false;
                    });
                }
            }
        }

        private void ViewHolder_Focused(object sender, FocusEventArgs e)
        {
            if(e.IsFocused)
            {
                ((sender as Xamarin.Forms.View).Parent.Parent as Grid).Children[0].BackgroundColor = Color.FromRgba(244, 244, 244, 200);
            }
            else
            {
                ((sender as Xamarin.Forms.View).Parent.Parent as Grid).Children[0].BackgroundColor = Color.Transparent;
            }
        }
    }
}