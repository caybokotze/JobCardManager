namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationRoleManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobStatusHistories", "JobCardId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobStatusHistories", "JobCardId");
        }
    }
}
