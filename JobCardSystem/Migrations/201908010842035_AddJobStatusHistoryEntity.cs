namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobStatusHistoryEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobStatusHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdated = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobStatusHistories");
        }
    }
}
