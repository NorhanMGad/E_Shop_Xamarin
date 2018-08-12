using Microsoft.Azure.Mobile.Server;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorhanXamarinTrainingService.DataObjects
{
    public class Item : EntityData
    {
        public string Title { set; get; }
        public string Descreption { set; get; }
        public double Price { set; get; }
        public int Quantity { set; get; }
        public String BaseImageUrl { set; get; }
        public virtual ICollection<Image> ItemImages { set; get; }
        public Item()
        {
            ItemImages = new HashSet<Image>();
        }
    }

    
}