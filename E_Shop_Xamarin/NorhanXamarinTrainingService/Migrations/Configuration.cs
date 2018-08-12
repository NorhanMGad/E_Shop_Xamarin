namespace NorhanXamarinTrainingService.Migrations
{
    using NorhanXamarinTrainingService.DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static System.Net.Mime.MediaTypeNames;

    internal sealed class Configuration : DbMigrationsConfiguration<NorhanXamarinTrainingService.Models.NorhanXamarinTrainingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new MyEntityTableSqlGenerator());
        }

        protected override void Seed(NorhanXamarinTrainingService.Models.NorhanXamarinTrainingContext context)
        {
            //context.Items.AddOrUpdate(
            //    new Item
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Quantity = 20,
            //        Descreption = "A smart TV device is either a television set with integrated Internet capabilities or a set top box for television that offers more advanced computing ability and connectivity",
            //        Price = 5000,
            //        Title = "LG Smart TV 40",
            //        BaseImageUrl = "https://i5.walmartimages.com/asr/a6a9b606-4d0f-433d-9117-16cab971e959_1.c041f29b42134fa5873e0d00447d0952.jpeg?odnHeight=180&odnWidth=180&odnBg=FFFFFF"
            //    },
            //    new Item
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Quantity = 20,
            //        Descreption = "A smart TV device is either a television set with integrated Internet capabilities or a set top box for television that offers more advanced computing ability and connectivity",
            //        Price = 2000,
            //        Title = "Samsung Smart TV 40",
            //        BaseImageUrl = "https://static.toiimg.com/photo/54150446/Sony-BRAVIA-KLV-32W562D-32-inch-LED-Full-HD-TV.jpg"
            //    });
            //context.SaveChanges();

            //List<DataObjects.Image> ItemImages = new List<DataObjects.Image>{
            //            new DataObjects.Image {  Id = Guid.NewGuid().ToString(),URI= "https://i5.walmartimages.com/asr/a6a9b606-4d0f-433d-9117-16cab971e959_1.c041f29b42134fa5873e0d00447d0952.jpeg?odnHeight=180&odnWidth=180&odnBg=FFFFFF" , RelatedItem=context.Items.FirstOrDefault(x=>x.Title=="LG Smart TV 40")},
            //        new DataObjects.Image{ Id = Guid.NewGuid().ToString(),URI="https://i.ebayimg.com/images/g/yegAAOSw-9xZyJpe/s-l300.jpg", RelatedItemID=context.Items.FirstOrDefault(x=>x.Title=="LG Smart TV 40").Id} ,
            //new DataObjects.Image {  Id = Guid.NewGuid().ToString(),URI= "https://static.toiimg.com/photo/54150446/Sony-BRAVIA-KLV-32W562D-32-inch-LED-Full-HD-TV.jpg", RelatedItemID=context.Items.FirstOrDefault(x=>x.Title=="Samsung Smart TV 40").Id},
            // new DataObjects.Image {Id = Guid.NewGuid().ToString(),URI="https://images.yaoota.com/ATWlVPoeJDo157-nopm0yZmnXtk=/trim/yaootaweb-production/media/crawledproductimages/9c709d19a89ed986d5e250be0fed45338ffc0ad7.jpg", RelatedItem=context.Items.FirstOrDefault(x=>x.Title=="Samsung Smart TV 40")}};

            //foreach (DataObjects.Image i in ItemImages)
            //{
            //    context.Set<DataObjects.Image>().AddOrUpdate(i);
            //}
            //context.SaveChanges();
        }
    }
}
