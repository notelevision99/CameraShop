namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMapLeftKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductImg", name: "CourseID", newName: "ProductID");
            RenameIndex(table: "dbo.ProductImg", name: "IX_CourseID", newName: "IX_ProductID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductImg", name: "IX_ProductID", newName: "IX_CourseID");
            RenameColumn(table: "dbo.ProductImg", name: "ProductID", newName: "CourseID");
        }
    }
}
