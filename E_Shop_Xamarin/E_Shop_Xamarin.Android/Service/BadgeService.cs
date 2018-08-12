using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Droid.Service;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(BadgeService))]
namespace E_Shop_Xamarin.Droid.Service
{
    public class BadgeService : IBadgeService
    {
        public void SetBadge(string value, Color backgroundColor, Color textColor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var CurrActivity = CrossCurrentActivity.Current.Activity;
                var toolbar = CurrActivity.FindViewById(Resource.Id.toolbar) as Android.Support.V7.Widget.Toolbar;
                if (toolbar != null)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (toolbar.Menu.Size() > 0)
                        {
                            var menuItem = toolbar.Menu.GetItem(0);
                            BadgeDrawable.SetBadgeText(CurrActivity, menuItem, value, backgroundColor.ToAndroid(), textColor.ToAndroid());
                        }
                    }
                }
            });
        }
    }
}