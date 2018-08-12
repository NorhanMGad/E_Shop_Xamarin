using E_Shop_Xamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace E_Shop_Xamarin
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            if (Properties.ContainsKey("UserName"))
                MainPage = new NavigationPage(new HomeView());
            else
                MainPage = new NavigationPage(new LoginView());

        }

		protected override void OnStart ()
		{
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
