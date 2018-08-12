using E_Shop_Xamarin.ClientManagers;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ViewModel
{
    public class ToolBarViewModel:BaseViewModel
    {
        private IPageService pageservice;
        private IApplicationService applicationService;
        static bool canExec = true;

        protected static double AllQuantity;

     
        public bool CanExec
        {
            set { SetValue(ref canExec, value); }
            get { return canExec; }
        }

        public ICommand CartCommand { get; private set; }
        public ICommand HomeCommand { get; private set; }
        public virtual ICommand FilterCommand { get; protected set; }
        public ICommand SyncCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public string UserName {
            get { return applicationService.GetAppProperty<string>("UserName"); }
        }

        public ToolBarViewModel(IPageService pageservice, IApplicationService applicationService)
        {
            this.pageservice = pageservice;
            this.applicationService = applicationService;
            CartCommand = new Command(async () => await NavToCart());
            HomeCommand = new Command(async () => await NavToHome());
            FilterCommand = new Command(() => { },()=>false);
            SyncCommand = new Command(async() => await SyncApplication(),()=> CanExec);
            LogoutCommand = new Command(()=> LogOut());
            MessagingCenter.Subscribe<LoginViewModel>(this, "SyncApplication", async (s) => await SyncApplication());
            UPdateQuantity();
        }

        private async Task NavToCart()
        {
            await pageservice.PushAsync(new CartView());
        }

        private async Task NavToHome()
        {
            await pageservice.PushAsync(new HomeView());
        }

        private async Task SyncApplication()
        {
            if (applicationService.IsConnected())
            {
                CanExec = false;
                MessagingCenter.Send<ToolBarViewModel>(this, "StartSync");
                await ItemManager.ManagerInstance.SyncItem();
                MessagingCenter.Send<ToolBarViewModel>(this, "FinishSync");
                CanExec = true;
                UPdateQuantity();
            }
            else
            {
               await pageservice.DisplayAlert("Network", "Please turn on internet connectivity", "Ok");
            }
        }

        private void LogOut()
        {
            applicationService.ClearProperties();
            pageservice.PushAsync(new LoginView());
        }

        public async void UPdateQuantity()
        {
            AllQuantity = await ItemManager.ManagerInstance.CountCartAsync();
            DependencyService.Get<IBadgeService>().SetBadge($"{AllQuantity}", Color.Red, Color.White);
        }

    }
}
