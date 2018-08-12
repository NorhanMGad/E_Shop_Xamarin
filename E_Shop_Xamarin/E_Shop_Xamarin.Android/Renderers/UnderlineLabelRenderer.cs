using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_Shop_Xamarin.Droid.Renderers;
using E_Shop_Xamarin.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRenderer))]
namespace E_Shop_Xamarin.Droid.Renderers
{
    class UnderlineLabelRenderer : LabelRenderer
    {
        public UnderlineLabelRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null && Element != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }

    }
}