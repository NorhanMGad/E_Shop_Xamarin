using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Models
{
    public class Item
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public string Descreption { set; get; }
        public double Price { set; get; }
        public int Quantity { set; get; }
        public String BaseImageUrl { set; get; }
        public virtual ICollection<Models.Image> ItemImages { set; get; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }


        public Item()
        {
            ItemImages = new HashSet<Models.Image>();
        }
    }
}
