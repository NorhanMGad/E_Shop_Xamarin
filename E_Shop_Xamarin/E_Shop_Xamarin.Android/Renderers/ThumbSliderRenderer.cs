using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_Shop_Xamarin.Droid.Renderers;
using E_Shop_Xamarin.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ThumbSlider), typeof(ThumbSliderRenderer))]

namespace E_Shop_Xamarin.Droid.Renderers
{
    public class ThumbSliderRenderer : SliderRenderer
    {
        private ThumbSlider view;

        public ThumbSliderRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            view = (ThumbSlider)Element;
            if (!string.IsNullOrEmpty(view.ThumbImage))
            {
                try
                {
                    Control.SetThumb(Resources.GetDrawable(view.ThumbImage));

                    Control.Thumb.SetColorFilter(Android.Graphics.Color.DarkGray, PorterDuff.Mode.SrcIn);
                    Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Gray);
                    Control.ProgressTintMode = PorterDuff.Mode.SrcIn;
                }
                catch
                {

                }
            }
            

        }
        
    }
}