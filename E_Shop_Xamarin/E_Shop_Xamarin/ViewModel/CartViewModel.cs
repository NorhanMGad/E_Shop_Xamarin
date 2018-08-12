using E_Shop_Xamarin.ClientManagers;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Models;
using E_Shop_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ViewModel
{
    public class CartViewModel:ToolBarViewModel
    {
        private IPageService pageService;
        private ObservableCollection<Cart> itemList;
        private static bool isLoading;
        private bool isEnabled;
        private UserManger usermanager;
        private IApplicationService applicationService;

        public ICommand DeleteCommand { get; private set; }
        public ICommand SubmitCommand { get; private set; }
        public ObservableCollection<Cart> ItemList
        {
            set { SetValue(ref itemList, value); }
            get { return itemList; }
        }
        public bool IsLoading
        {
            set { SetValue(ref isLoading, value); }
            get { return isLoading; }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        public CartViewModel(IPageService pageService, IApplicationService applicationService):base(pageService, applicationService)
        {
            this.pageService = pageService;
            this.applicationService = applicationService;
            DeleteCommand = new Command(item => DeleteItem(item as Cart));
            SubmitCommand = new Command(() => SubmitOrder());
            usermanager = new UserManger();
            LoadData();
        }

        public async void LoadData()
        {
            ItemList = new ObservableCollection<Cart>(await ItemManager.ManagerInstance.GetCartAsync());
            CheckCart();
        }

        public async void SubmitOrder()
        {
            IsLoading = true;
            
            if (!applicationService.IsConnected())
            {
                await pageService.DisplayAlert("Network", "Please turn on internet connectivity in order to submit your order", "Ok");
            }
            else
            {
                usermanager.submitorder(1, new List<Cart>(await ItemManager.ManagerInstance.GetCartAsync()));
                await ItemManager.ManagerInstance.SubmitOrder();
                await pageService.DisplayAlert("Done", "Order was submitted successfully", "Ok");
                await pageService.PushAsync(new HomeView());
                UPdateQuantity();
            }
            IsLoading = false;
        }

        public async void DeleteItem(Cart item)
        {
            await ItemManager.ManagerInstance.RemoveFromCart(item);
            ItemList.Remove(item);
            UPdateQuantity();
            CheckCart();
        }

        public async void CheckCart()
        {
            if (ItemList.Count == 0)
            {
                IsEnabled = false;
                await pageService.DisplayAlert("Empty", "Cart Is Empty", "OK");
            }
            else
                IsEnabled = true;
        }
    }
}
