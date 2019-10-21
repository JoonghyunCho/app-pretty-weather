using PrettyWeather.Tizen;
using System;
using Tizen.Appium;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(PrettyWeather.MyCollectionView), typeof(MyCollectionViewRenderer))]
[assembly: ExportRenderer(typeof(PrettyWeather.ViewHolder), typeof(ViewHolderRenderer))]
namespace PrettyWeather.Tizen
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Forms.Init(app);
            TizenAppium.StartService();
            ElmSharp.Elementary.FocusAutoScrollMode = ElmSharp.FocusAutoScrollMode.Show;
            app.Run(args);
        }
    }
}
