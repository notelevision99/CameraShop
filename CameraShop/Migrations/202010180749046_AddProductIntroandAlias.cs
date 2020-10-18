namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductIntroandAlias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Alias", c => c.String());
            AddColumn("dbo.Product", "ProductIntro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductIntro");
            DropColumn("dbo.Product", "Alias");
        }
    }
}
