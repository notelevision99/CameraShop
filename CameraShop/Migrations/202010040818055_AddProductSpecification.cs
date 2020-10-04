namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductSpecification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductSpecification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductSpecification");
        }
    }
}
