using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Renderers
{
    public class SelectedViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create("SelectedColor",typeof(Color),typeof(SelectedViewCell),Color.Default);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
    }
}
