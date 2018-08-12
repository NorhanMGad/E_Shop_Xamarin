using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorhanXamarinTrainingService.DataObjects
{
    public class Image : EntityData
    {
        public string URI { get; set; }
        public string RelatedItemID { get; set; }

        [ForeignKey("RelatedItemID")]
        public Item RelatedItem { get; set; }
    }
}