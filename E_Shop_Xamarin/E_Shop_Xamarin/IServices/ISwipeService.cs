using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.IServices
{
    public interface ISwipeService
    {
        void onLeftSwipe(View view = null);
        void onRightSwipe(View view = null);
    }
}
