namespace NorhanXamarinTrainingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Carts", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "UserID");
            AddForeignKey("dbo.Carts", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "UserID", "dbo.Users");
            DropIndex("dbo.Carts", new[] { "UserID" });
            DropColumn("dbo.Carts", "UserID");
            DropTable("dbo.Users");
        }
    }
}
