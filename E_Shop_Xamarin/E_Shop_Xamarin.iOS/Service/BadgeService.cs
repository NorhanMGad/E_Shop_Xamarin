using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E_Shop_Xamarin.iOS.Service;
using E_Shop_Xamarin.IServices;
using Foundation;
using ObjCRuntime;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using E_Shop_Xamarin.iOS.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace E_Shop_Xamarin.iOS.Service
{
    class BadgeService : IBadgeService
    {
        public void SetBadge(string value, Color backgroundColor, Color textColor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;

                var rightButtomItems = vc?.ParentViewController?.NavigationItem?.RightBarButtonItems;
                var idx = 0;
                if (rightButtomItems != null && rightButtomItems.Length > idx)
                {
                    var barItem = rightButtomItems[idx];
                    if (barItem != null)
                    {
                        barItem.UpdateBadge(value, backgroundColor.ToUIColor(), textColor.ToUIColor());
                    }
                }

            });
        }
    }
}