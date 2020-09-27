namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCre : DbMigration
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
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(),
                        OriPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.EnrollmentImage",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        file_id = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.FileImg", t => t.file_id)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.file_id)
                .Index(t => t.ProductID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product");
            DropForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.EnrollmentImage", new[] { "ProductID" });
            DropIndex("dbo.EnrollmentImage", new[] { "file_id" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.FileImg");
            DropTable("dbo.EnrollmentImage");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
