using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.IServices
{
    public interface IBadgeService
    {
        void SetBadge(string value, Color backgroundColor, Color textColor);
    }
}
