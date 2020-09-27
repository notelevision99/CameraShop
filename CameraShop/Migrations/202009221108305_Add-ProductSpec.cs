namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductSpec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSpecification",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        FirstTitle = c.String(),
                        SecondTitle = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSpecification", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductSpecification", new[] { "ProductID" });
            DropTable("dbo.ProductSpecification");
        }
    }
}
