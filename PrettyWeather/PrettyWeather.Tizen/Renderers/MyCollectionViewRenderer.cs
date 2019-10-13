using System;
using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;

namespace PrettyWeather.Tizen
{
    public class MyCollectionView : Xamarin.Forms.Platform.Tizen.Native.CollectionView, ICollectionViewController
    {
        //EcoreEvent<EcoreKeyEventArgs> _ecoreKeyDown;
        //EventHandler<EcoreKeyEventArgs> _keyDownHandler;

        public MyCollectionView(EvasObject parent) : base(parent)
        {
            //_ecoreKeyDown = new EcoreEvent<EcoreKeyEventArgs>(EcoreEventType.KeyDown, EcoreKeyEventArgs.Create);
            //_ecoreKeyDown.On += _ecoreKeyDown_On;
        }

        //private void _ecoreKeyDown_On(object sender, EcoreKeyEventArgs e)
        //{
        //    Console.WriteLine($"####### keydown e.KeyCode:{e.KeyCode} e.KeyName:{e.KeyName}");
        //    if(this.IsFocused)
        //    {
        //        if (e.KeyCode == 114)
        //        {
        //            Console.WriteLine($"####### Scroll to Right:");
        //        }
        //        else if (e.KeyCode == 113)
        //        {
        //            Console.WriteLine($"####### Scroll to Left :");
        //        }
        //    }
        //}

        protected override ElmSharp.Scroller CreateScroller(EvasObject parent)
        {
            var _scroller = base.CreateScroller(parent);
            _scroller.HorizontalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Invisible;

            return _scroller;
        }
    }

    class MyCollectionViewRenderer : ItemsViewRenderer
    {
        public MyCollectionViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StructuredItemsView> e)
        {
            SetNativeControl(new MyCollectionView(Forms.NativeParent));
            base.OnElementChanged(e);

            if (Control.Adaptor != null)
            {
            }
            //(Element as Xamarin.Forms.CollectionView).SelectionChanged += MyCollectionViewRenderer_SelectionChanged; ;
            //Console.WriteLine("OnElementChanged 2 " +( (Element as Xamarin.Forms.CollectionView).SelectedItem as City).Name);
            //var renderer = Platform.GetOrCreateRenderer(item);
            //(renderer.NativeView as ViewHolder).FocusedColor = ElmSharp.Color.Red;// NativeView.Color
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //
        //    if(e.PropertyName == "SelectedItem")
        //    {
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            if(Element !=null && (Element as Xamarin.Forms.CollectionView).SelectedItem != null)
        //            {
        //                //Console.WriteLine($"=== Select Request: {Control.SelectedItemIndex}");
        //                //Control.Adaptor?.RequestItemSelected((Element as Xamarin.Forms.CollectionView).SelectedItem);
        //            }
        //        });
        //
        //        //Control.ScrollTo(Control.SelectedItemIndex, Xamarin.Forms.ScrollToPosition.Center, true);
        //    }
        //}
    }
}
