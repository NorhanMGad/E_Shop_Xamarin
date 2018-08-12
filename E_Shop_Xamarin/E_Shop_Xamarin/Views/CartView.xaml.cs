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
	public partial class CartView : ToolBarView
    {
		public CartView ()
		{
            InitializeComponent ();
            this.BindingContext = new CartViewModel(new PageService(), new ApplicationService());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Confirmation", "Are You Sure?", "OK");
        }
    }
}