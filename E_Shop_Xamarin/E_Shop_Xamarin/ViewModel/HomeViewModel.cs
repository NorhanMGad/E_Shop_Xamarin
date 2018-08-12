using E_Shop_Xamarin.ClientManagers;
using E_Shop_Xamarin.IServices;
using E_Shop_Xamarin.Models;
using E_Shop_Xamarin.Services;
using E_Shop_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace E_Shop_Xamarin.ViewModel
{
    public class HomeViewModel:ToolBarViewModel
    {
        private IPageService pageService;
        private bool filtervisibilty;
        private ObservableCollection<Item> itemlist;
        private static bool isLoading;
        private bool isRefreshing = false;
        public ObservableCollection<Item> ItemList
        {
            set { SetValue(ref itemlist, value); }
            get { return itemlist; }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                SetValue(ref isRefreshing, value);
            }
        }

        public bool IsLoading
        {
            set { SetValue(ref isLoading, value); }
            get { return isLoading; }
        }
        public bool FilterVisibilty
        {
            set { SetValue(ref filtervisibilty, value); }
            get { return filtervisibilty; }
        }
        public ICommand SelectedCommand { get; protected set; }

        public ICommand ApplyCmd { get; protected set; }

        public ICommand RefreshCommand { get; protected set;}

        public override ICommand FilterCommand { get; protected set; }

        public double MinValue { set; get; }
        public double MaxValue { set; get; }


        public HomeViewModel(IPageService pageService, IApplicationService applicationService):base(pageService, applicationService)
        {
            this.pageService = pageService;
            FilterCommand = new Command(()=>ShowFilter(),()=> true);
            SelectedCommand = new Command(item => SelectedItem(item as Item));
            RefreshCommand = new Command(() => RefreshList());
            ApplyCmd = new Command(ApplyFilter);
            ItemList = new ObservableCollection<Item>();
            MessagingCenter.Subscribe<ToolBarViewModel>(this, "StartSync", (s)=> StartSync());
            MessagingCenter.Subscribe<ToolBarViewModel>(this, "FinishSync", (s) => FinishSync());
            FilterVisibilty = false;
            LoadData();
        }

        public  void FinishSync()
        {
            LoadData();
            IsLoading = false;
        }

        public void StartSync()
        {
            IsLoading = true;
        }

        public async void LoadData()
        {
            ItemList = new ObservableCollection<Item>(await ItemManager.ManagerInstance.GetAllItemsLocal());
        }

        public void ShowFilter()
        {
            FilterVisibilty = true;
        }

        public void RefreshList()
        {
            IsRefreshing = true;
            LoadData();
            IsRefreshing = false;
        }

        public async void ApplyFilter()
        {
            var lst = (await ItemManager.ManagerInstance.GetAllItemsLocal()).ToList();
             lst = lst.Where(x => x.Price >= MinValue && x.Price <= MaxValue).ToList();
            FilterVisibilty = false;
            if (lst.Count > 0)
                ItemList = new ObservableCollection<Item>(lst.Where(x => x.Price >= MinValue && x.Price <= MaxValue).ToList());
            else
                await pageService.DisplayAlert("Sorry", "No Result is Matched", "OK");
            
        }

        private void SelectedItem(Item SelectedItem)
        {
            var page = new DetailView();
            //var viewmodel = new DetailViewModel(new PageService(), new ApplicationService()) { ItemDetail = SelectedItem };
            pageService.PushAsync(page,()=> { MessagingCenter.Send<HomeViewModel, Item>(this, "DisplayItem", SelectedItem); });
        }
    }
}
