using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E_Shop_Xamarin.iOS.Renderers;
using E_Shop_Xamarin.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ThumbSlider), typeof(ThumbSliderRenderer))]
namespace E_Shop_Xamarin.iOS.Renderers
{
    public class ThumbSliderRenderer : SliderRenderer
    {
        private ThumbSlider view;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            view = (ThumbSlider)Element;
            if (!string.IsNullOrEmpty(view.ThumbImage))
            {
                Control.SetThumbImage(UIImage.FromFile(view.ThumbImage), UIControlState.Normal);
            }
            Control.ThumbTintColor = Color.Gray.ToUIColor();
            Control.MinimumTrackTintColor = Color.Gray.ToUIColor();

        }
    }
}