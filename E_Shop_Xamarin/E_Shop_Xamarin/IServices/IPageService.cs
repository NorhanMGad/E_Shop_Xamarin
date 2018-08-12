using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_Shop_Xamarin.IServices
{
    public interface IPageService
    {
        Task PushAsync(Page page,Action ExecuteAction = null);
        Task PushAsync<T>(Page page, T ViewModel, Action ExecuteAction = null);
        Task<Page> PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
