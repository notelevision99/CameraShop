namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataAnotationOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CustomerName", c => c.String());
            AlterColumn("dbo.Order", "CustomerPhone", c => c.String());
            AlterColumn("dbo.Order", "CustomerEmail", c => c.String());
            AlterColumn("dbo.Order", "CustomerAddress", c => c.String());
            AlterColumn("dbo.Order", "OrderNote", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "OrderNote", c => c.String(maxLength: 200));
            AlterColumn("dbo.Order", "CustomerAddress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "CustomerEmail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "CustomerPhone", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.Order", "CustomerName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
