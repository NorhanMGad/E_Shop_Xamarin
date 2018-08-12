using E_Shop_Xamarin.ClientManagers;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ViewModel
{
    public class DetailViewModel : ToolBarViewModel, ISwipeService
    {
        private IPageService pageService;
        private IApplicationService applicationService;
        private string imagedetail;
        private int currImageIndex=0;
        private Item itemdetail;
        public Item ItemDetail
        {
            set {
                    SetValue(ref itemdetail, value);
                    //ImageDetail = value.ItemImages.ElementAt(0).URI;
                    ImageDetail = GetFullPath(value.ItemImages.ElementAt(0).Id);
            }
            get { return itemdetail; }
        }

        public string ImageDetail
        {
            set { SetValue(ref imagedetail, value); }
            get { return imagedetail; }
        }

        public ICommand AddToCartCommand { get; private set; }

        public DetailViewModel(IPageService pageService, IApplicationService applicationService):base(pageService, applicationService)
        {
            this.pageService = pageService;
            this.applicationService = applicationService;
            MessagingCenter.Subscribe<HomeViewModel,Item>(this, "DisplayItem", (sender, arg) => {
                this.ItemDetail = arg;
            });
            AddToCartCommand = new Command((quant) => AddToCart(Convert.ToInt32(quant)));
        }

        public void onLeftSwipe(View view = null)
        {
            if(ItemDetail.ItemImages.Count()-1> currImageIndex)
            {
                currImageIndex++;
               // ImageDetail = ItemDetail.ItemImages.ElementAt(currImageIndex).URI;
                ImageDetail = GetFullPath(ItemDetail.ItemImages.ElementAt(currImageIndex).Id);
            }
        }

        public void onRightSwipe(View view = null)
        {
            if (ItemDetail.ItemImages.Count() - 1 <= currImageIndex)
            {
                currImageIndex--;
                //ImageDetail = ItemDetail.ItemImages.ElementAt(currImageIndex).URI;
                ImageDetail =  GetFullPath(ItemDetail.ItemImages.ElementAt(currImageIndex).Id);
            }
        }

        private async void AddToCart(int quant)
        {
            var cartitem = new Cart()
            {
                RelatedItem = itemdetail,
                UserQuantity = quant,
                RelatedItemID = itemdetail.Id,
                UserID = applicationService.GetAppProperty<int>("UserId")
            };
            if (!await ItemManager.ManagerInstance.AddToCart(cartitem))
            {
                await pageService.DisplayAlert("Sorry", "Unavailable Quantity", "Ok");
            }
            else
            {
                await pageService.PopAsync();
                UPdateQuantity();
                await pageService.DisplayAlert("Successfully added", "Cart updated successfully", "Ok");
            }
        }

        private string GetFullPath(string ImageName)
        {
            return DependencyService.Get<IFileService>().RetrivePictureFullPath($"{ImageName}.jpg");
        }
    }
}
