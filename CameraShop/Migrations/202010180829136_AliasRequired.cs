namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AliasRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Alias", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Alias", c => c.String());
        }
    }
}
