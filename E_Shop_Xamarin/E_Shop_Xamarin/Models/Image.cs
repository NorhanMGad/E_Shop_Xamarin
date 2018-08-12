using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop_Xamarin.Models
{
    public class Image
    {
        public string Id { set; get; }
        public string URI { get; set; }

        public string RelatedItemID { get; set; }
        public virtual Item RelatedItem { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string EmbImageName { get; set; }
    }
}
