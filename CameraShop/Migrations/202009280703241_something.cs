namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg");
            DropForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product");
            DropIndex("dbo.EnrollmentImage", new[] { "file_id" });
            DropIndex("dbo.EnrollmentImage", new[] { "ProductID" });
            DropTable("dbo.EnrollmentImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EnrollmentImage",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        file_id = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID);
            
            CreateIndex("dbo.EnrollmentImage", "ProductID");
            CreateIndex("dbo.EnrollmentImage", "file_id");
            AddForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg", "file_id");
        }
    }
}
