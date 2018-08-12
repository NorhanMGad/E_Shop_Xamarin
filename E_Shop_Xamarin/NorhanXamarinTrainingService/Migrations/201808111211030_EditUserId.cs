namespace NorhanXamarinTrainingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "user", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "UserID");
        }
    }
}
