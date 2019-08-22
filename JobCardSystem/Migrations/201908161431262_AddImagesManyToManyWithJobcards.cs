namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesManyToManyWithJobcards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dir = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageJobCards",
                c => new
                    {
                        Image_Id = c.Int(nullable: false),
                        JobCard_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Image_Id, t.JobCard_Id })
                .ForeignKey("dbo.Images", t => t.Image_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobCards", t => t.JobCard_Id, cascadeDelete: true)
                .Index(t => t.Image_Id)
                .Index(t => t.JobCard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageJobCards", "JobCard_Id", "dbo.JobCards");
            DropForeignKey("dbo.ImageJobCards", "Image_Id", "dbo.Images");
            DropIndex("dbo.ImageJobCards", new[] { "JobCard_Id" });
            DropIndex("dbo.ImageJobCards", new[] { "Image_Id" });
            DropTable("dbo.ImageJobCards");
            DropTable("dbo.Images");
        }
    }
}
