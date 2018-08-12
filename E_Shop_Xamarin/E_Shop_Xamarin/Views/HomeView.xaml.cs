using E_Shop_Xamarin.Services;
using E_Shop_Xamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_Shop_Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ToolBarView
    {
		public HomeView()
		{
            this.BindingContext = new HomeViewModel(new PageService(), new ApplicationService());
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            if((this.BindingContext as HomeViewModel).FilterVisibilty == true)
            {
                (this.BindingContext as HomeViewModel).FilterVisibilty = false;
            }
            return true;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (this.BindingContext as HomeViewModel).SelectedCommand.Execute(e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
        }

        //protected override void OnAppearing()
        //{
        //    (this.BindingContext as HomeViewModel).LoadData();
        //}

    }
}