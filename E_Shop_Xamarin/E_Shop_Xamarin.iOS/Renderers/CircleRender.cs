using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using E_Shop_Xamarin.iOS.Renderers;
using E_Shop_Xamarin.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Circle), typeof(CircleRender))]

namespace E_Shop_Xamarin.iOS.Renderers
{
    public class CircleRender : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                Layer.MasksToBounds = true;
                UpdateCornerRadius(Element as Circle);
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Circle.CornerRadiusProperty.PropertyName)
            {
                UpdateCornerRadius(Element as Circle);
            }
        }

        void UpdateCornerRadius(Circle box)
        {
            Layer.CornerRadius = (float)box.CornerRadius;
        }
    }

}