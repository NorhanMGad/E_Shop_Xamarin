using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop_Xamarin.Models
{
    public class Cart
    {
        public string Id { set; get; }
        public int UserQuantity { get; set; }
        public string RelatedItemID { get; set; }
        public int UserID { get; set; }
        public virtual Item RelatedItem { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string StockState
        {
            get
            {
                if (RelatedItem.Quantity > 0)
                    return "In Stock";
                else
                    return "Out Of Stock";
            }
        }
    }
}
