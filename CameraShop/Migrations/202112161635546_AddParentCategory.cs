namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "CategoryParentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "CategoryParentID", c => c.Int(nullable: false));
        }
    }
}
