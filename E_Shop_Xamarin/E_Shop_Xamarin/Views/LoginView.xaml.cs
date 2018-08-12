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
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
            this.BindingContext = new LoginViewModel(new PageService(), new ApplicationService());
            InitializeComponent ();
		}

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}