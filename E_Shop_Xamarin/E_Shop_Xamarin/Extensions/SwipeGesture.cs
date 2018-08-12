using E_Shop_Xamarin.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Extensions
{
    public class SwipeGesture : PanGestureRecognizer
    {
        private ISwipeService SwipeService;
        private double translatedX = 0, translatedY = 0;

        public SwipeGesture(View view, ISwipeService SwipeService)
        {
            this.SwipeService = SwipeService;
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            view.GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            View Content = (View)sender;
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                        try
                        {
                            translatedX = e.TotalX;
                            translatedY = e.TotalY;
                        }
                        catch
                        {
                        }
                    break;

                case GestureStatus.Completed:
                        if (translatedX < 0 && Math.Abs(translatedX) > Math.Abs(translatedY))
                        {
                            SwipeService.onLeftSwipe(Content);
                        }
                        else if (translatedX > 0 && translatedX > Math.Abs(translatedY))
                        {
                            SwipeService.onRightSwipe(Content);
                        }
                    break;
            }
        }
    }
}
