namespace CameraShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNavigaPropProductandFileImg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product");
            DropForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg");
            DropIndex("dbo.EnrollmentImage", new[] { "file_id" });
            DropIndex("dbo.EnrollmentImage", new[] { "ProductID" });
            DropPrimaryKey("dbo.EnrollmentImage");
            CreateTable(
                "dbo.ProductImg",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        file_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.file_id })
                .ForeignKey("dbo.Product", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.FileImg", t => t.file_id, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.file_id);
            
            AlterColumn("dbo.EnrollmentImage", "file_id", c => c.Int());
            AlterColumn("dbo.EnrollmentImage", "ProductID", c => c.Int());
            AlterColumn("dbo.EnrollmentImage", "EnrollmentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EnrollmentImage", "EnrollmentID");
            CreateIndex("dbo.EnrollmentImage", "file_id");
            CreateIndex("dbo.EnrollmentImage", "ProductID");
            AddForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg", "file_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg");
            DropForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductImg", "file_id", "dbo.FileImg");
            DropForeignKey("dbo.ProductImg", "CourseID", "dbo.Product");
            DropIndex("dbo.ProductImg", new[] { "file_id" });
            DropIndex("dbo.ProductImg", new[] { "CourseID" });
            DropIndex("dbo.EnrollmentImage", new[] { "ProductID" });
            DropIndex("dbo.EnrollmentImage", new[] { "file_id" });
            DropPrimaryKey("dbo.EnrollmentImage");
            AlterColumn("dbo.EnrollmentImage", "EnrollmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnrollmentImage", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnrollmentImage", "file_id", c => c.Int(nullable: false));
            DropTable("dbo.ProductImg");
            AddPrimaryKey("dbo.EnrollmentImage", new[] { "file_id", "ProductID" });
            CreateIndex("dbo.EnrollmentImage", "ProductID");
            CreateIndex("dbo.EnrollmentImage", "file_id");
            AddForeignKey("dbo.EnrollmentImage", "file_id", "dbo.FileImg", "file_id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentImage", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
