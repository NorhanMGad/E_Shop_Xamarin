namespace NorhanXamarinTrainingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "UserID", "dbo.Users");
            DropIndex("dbo.Carts", new[] { "UserID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Carts", "UserID");
            AddForeignKey("dbo.Carts", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
