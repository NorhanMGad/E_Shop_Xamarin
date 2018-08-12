using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Renderers
{
    public class Circle : BoxView
    {
        public static readonly BindableProperty
            CornerRadiusProperty = BindableProperty.Create(
                nameof(CornerRadius),
                typeof(double),
                typeof(Circle), 0.0);

        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
