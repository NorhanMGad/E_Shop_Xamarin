using System;
using System.Collections.Generic;
using System.Text;
using E_Shop_Xamarin.IServices;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Services
{
    public class ApplicationService : IApplicationService
    {
        public void AddAppProperty<T>(string Key, T Value)
        {
            CurrApp.Properties[Key] = Value;
        }

        public T GetAppProperty<T>(string Key)
        {
            if (CurrApp.Properties.ContainsKey(Key))
                return (T)CurrApp.Properties[Key];
            else
                return default(T);
        }

        public void ClearProperties()
        {
            CurrApp.Properties.Clear();
        }

        public bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        private Application CurrApp
        {
            get { return Application.Current; }
        }
    }
}
