namespace NorhanXamarinTrainingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "user", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "user");
        }
    }
}
