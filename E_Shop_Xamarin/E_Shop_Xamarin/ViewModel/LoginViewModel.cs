using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using E_Shop_Xamarin.ClientManagers;
using System.Windows.Input;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        private IPageService pageService;
        private IApplicationService applicationService;
        private bool isEnabled;
        private string username = string.Empty;
        public ICommand LoginCommand { get; private set; }
        public bool IsEnabled {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
         public string UserName {
            set
            {
                SetValue(ref username, value);
                IsEnabled = !(string.IsNullOrEmpty(username.Trim()) || string.IsNullOrWhiteSpace(username.Trim()));
            }
            get { return username; }
        }

        public LoginViewModel(IPageService pageService, IApplicationService applicationService)
        {
            IsEnabled = false;
            this.pageService = pageService;
            this.applicationService = applicationService;
            LoginCommand = new Command(()=> Login());
        }

        private async void Login()
        {
            if (CheckUserName())
            {
                if (applicationService.IsConnected())
                {
                    Page HomePage = new HomeView();
                     UserManger usermanger = new UserManger();
                    int userId  = await usermanger.AddUser(username);
                    Task.WaitAll();
                    applicationService.AddAppProperty<string>("UserName", username);
                    applicationService.AddAppProperty<int>("UserId", userId);
                    await pageService.PushAsync(HomePage, () => { MessagingCenter.Send<LoginViewModel>(this, "SyncApplication"); });
                }
                else
                {
                    await pageService.DisplayAlert("Network", "Please turn on internet connectivity", "Ok");
                }
                    
            }
            else
            {
               await pageService.DisplayAlert("Invalid User Name", "User Name Must Not Contain Any Spaces Or Special Characters.", "Ok");
            }
        }

        private bool CheckUserName()
        {
            Regex regexItem = new Regex("^[a-zA-Z]*$");
            if (!regexItem.IsMatch(username)|| String.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                return false;

            return true;
        }
    }
}
