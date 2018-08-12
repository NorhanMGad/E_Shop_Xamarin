using E_Shop_Xamarin.Services;
using E_Shop_Xamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_Shop_Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolBarView : ContentPage
    {
		public ToolBarView()
		{
            InitializeComponent ();
        }
        protected override bool OnBackButtonPressed()
        {
            back();
            return true;
        }

        private async void back()
        {
             await Navigation.PopAsync();
            (this.BindingContext as ToolBarViewModel).UPdateQuantity();
        }
    }
}