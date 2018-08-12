using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_Shop_Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterView : ContentView
    {
        public static readonly BindableProperty ApplyCommandProperty = BindableProperty.Create("ApplyCommand", typeof(ICommand), typeof(FilterView), null);
        public static readonly BindableProperty MinProperty = BindableProperty.Create("Min", typeof(double), typeof(FilterView), 0d,BindingMode.TwoWay);
        public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(double), typeof(FilterView), 0d, BindingMode.TwoWay);

        public ICommand ApplyCommand
        {
            get { return (ICommand)GetValue(ApplyCommandProperty); }
            set { SetValue(ApplyCommandProperty, value); }
        }

        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
        public FilterView ()
		{
			InitializeComponent ();
		}

        private void MinSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Min = e.NewValue;
            
        }

        private void MaxSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Max = e.NewValue;
        }
    }
}