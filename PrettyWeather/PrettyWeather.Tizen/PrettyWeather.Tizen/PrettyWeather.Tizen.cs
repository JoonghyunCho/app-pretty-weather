using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(CollectionView), typeof(ItemsViewRenderer))]
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
            app.Run(args);
        }
    }
}
