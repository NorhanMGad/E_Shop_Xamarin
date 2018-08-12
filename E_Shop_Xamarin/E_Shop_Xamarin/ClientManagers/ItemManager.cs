using E_Shop_Xamarin.Handlers;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Models;
using E_Shop_Xamarin.Services;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ClientManagers
{
    public class ItemManager
    {
       public  static ItemManager ManagerInstance = new ItemManager();
        IMobileServiceClient client;
        IMobileServiceSyncTable<E_Shop_Xamarin.Models.Image> imageTable;
        IMobileServiceSyncTable<Item> itemTable;
        IMobileServiceSyncTable<Cart> cartTable;
        MobileServiceSQLiteStore LocalStore;
        List<string> lstImagesId;
        ApplicationService applicationservice;
        int UserId;

        public object DepdendencyService { get; private set; }

        private ItemManager()
        {
            client = new MobileServiceClient(Constants.ServiceURL);
            LocalStore = new MobileServiceSQLiteStore(Constants.LocalDbName);
            applicationservice = new ApplicationService();
            LocalStore.DefineTable<E_Shop_Xamarin.Models.Image>();
            LocalStore.DefineTable<Item>();
            LocalStore.DefineTable<Cart>();
            client.SyncContext.InitializeAsync(LocalStore);
            imageTable = client.GetSyncTable<E_Shop_Xamarin.Models.Image>();
            itemTable = client.GetSyncTable<Item>();
            cartTable = client.GetSyncTable<Cart>();
        }

        public async Task SyncItem()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;

                lstImagesId = new List<string>();
                UserId = applicationservice.GetAppProperty<int>("UserId");
                await client.SyncContext.PushAsync();
                await itemTable.PullAsync(Constants.ItemQueryName, itemTable.CreateQuery());
                await imageTable.PullAsync(Constants.ImageQueryName, imageTable.CreateQuery());
                await cartTable.PullAsync(Constants.CartQueryName, cartTable.CreateQuery().Where(c=>c.UserID==UserId));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await DownLoadImages();
            }
        }
        public async Task<IEnumerable<Item>> GetAllItemsLocal()
        {
            var ItemList = await itemTable?.OrderBy(i => i.Price).ToEnumerableAsync();
            if (ItemList == null)
                return new List<Item>();
            return ItemList;
        }

        public async Task<bool> AddToCart (Cart cartitem)
        {
            var lstItem = await GetCart();
            lstItem = lstItem.FindAll(c => c.RelatedItemID == cartitem.RelatedItemID);
            var item = await itemTable.LookupAsync(cartitem.RelatedItemID);
            int allUserCount = cartitem.UserQuantity;
            foreach(var c in lstItem)
            {
                allUserCount += c.UserQuantity;
            }
            if (item.Quantity >= allUserCount)
            {
                await cartTable.InsertAsync(cartitem);
                return true;
            }
            return false;
        }

        public async Task RemoveFromCart(Cart cartitem)
        {
            await cartTable.DeleteAsync(cartitem);
        }

        public async Task<IEnumerable<Cart>> GetCartAsync()
        {
            var CartList = await GetCart();
            if (CartList == null)
                return new List<Cart>();
            return CartList;
        }

        public async Task<int> CountCartAsync()
        {
            int count = 0;
            var CartList = await GetCart();
            foreach(var c in CartList)
                count += c.UserQuantity;

            return count;
        }

        public async Task<bool> SubmitOrder()
        {
            if (!CrossConnectivity.Current.IsConnected)
                return false;
            try
            {
                var CartList = await GetCart();
            foreach (var c in CartList)
                await cartTable.DeleteAsync(c);

                await client.SyncContext.PushAsync();
                await SyncItem();
            }
            catch(Exception ex)
            {

            }

            return true;
        }

        private async Task DownLoadImages()
        {
                HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
                string imageName;
                foreach (Models.Image i in await imageTable.ToEnumerableAsync())
                {
                    imageName = $"{i.Id}.jpg";
                    try
                    {
                        if (!DependencyService.Get<IFileService>().IfExsist(imageName))
                            {
                                byte[] data = await client.GetByteArrayAsync(i.URI);
                                DependencyService.Get<IFileService>().SavePicture(imageName, data);
                            }
                    }
                    catch(Exception ex)
                    {

                    }
                }
        }

        private async  Task<List<Cart>> GetCart()
        {
            UserId = applicationservice.GetAppProperty<int>("UserId");
            var queryResult =  await cartTable.Where(c => c.UserID == UserId).ToListAsync();
            foreach( var c in queryResult)
            {
                c.RelatedItem = await itemTable.LookupAsync(c.RelatedItemID);
            }
            return queryResult;
        }
    }
}
