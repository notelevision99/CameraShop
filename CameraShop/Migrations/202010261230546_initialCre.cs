namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductSKU = c.String(nullable: false),
                        ProductName = c.String(),
                        OriPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alias = c.String(nullable: false),
                        DiscountedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductSpecification = c.String(),
                        ProductIntro = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.FileImg",
                c => new
                    {
                        file_id = c.Int(nullable: false, identity: true),
                        file_name = c.String(),
                        file_ext = c.String(),
                        file_base6 = c.String(),
                    })
                .PrimaryKey(t => t.file_id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                        OrderNote = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.ProductImg",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        file_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.file_id })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.FileImg", t => t.file_id, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.file_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.ProductImg", "file_id", "dbo.FileImg");
            DropForeignKey("dbo.ProductImg", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.ProductImg", new[] { "file_id" });
            DropIndex("dbo.ProductImg", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.ProductImg");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.FileImg");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
