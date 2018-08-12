using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Renderers
{
    public class ThumbSlider : Slider
    {
        public static readonly BindableProperty ThumbImageProperty = BindableProperty.Create(nameof(ThumbImage),
              typeof(string), typeof(ThumbSlider), string.Empty);

        public string ThumbImage
        {
            get { return (string)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }
    }
}
