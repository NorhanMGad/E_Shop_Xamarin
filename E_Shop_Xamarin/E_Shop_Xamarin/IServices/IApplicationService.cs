using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop_Xamarin.IServices
{
    public interface IApplicationService
    {
        void AddAppProperty<T>(string Key, T Value);
        T GetAppProperty<T>(string Key);
        void ClearProperties();
        bool IsConnected();
    }
}
