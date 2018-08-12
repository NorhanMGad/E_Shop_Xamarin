using E_Shop_Xamarin.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Services
{
    public class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page, Action ExecuteAction=null)
        {
            var stack = MainPage.Navigation.NavigationStack;
            if (page.GetType() != stack[stack.Count - 1].GetType())
            {
                await MainPage.Navigation.PushAsync(page);
                if (ExecuteAction != null)
                    ExecuteAction();
            }
        }

        public async Task PushAsync<T>(Page page,T ViewModel, Action ExecuteAction = null)
        {
            page.BindingContext = ViewModel;
            await PushAsync(page, ExecuteAction);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }


        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
