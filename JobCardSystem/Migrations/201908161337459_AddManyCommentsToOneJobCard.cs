namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyCommentsToOneJobCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.JobCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "JobCardId", "dbo.JobCards");
            DropIndex("dbo.Comments", new[] { "JobCardId" });
            DropTable("dbo.Comments");
        }
    }
}
