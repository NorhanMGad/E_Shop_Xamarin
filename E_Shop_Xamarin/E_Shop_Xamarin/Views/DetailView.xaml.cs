using E_Shop_Xamarin.Extensions;
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
	public partial class DetailView : ToolBarView
    {
		public DetailView ()
		{
			InitializeComponent ();
            this.BindingContext = new DetailViewModel(new PageService(), new ApplicationService());
            SwipeGesture swipegesture = new SwipeGesture(this.Image, this.BindingContext as DetailViewModel);
        }
    }
}