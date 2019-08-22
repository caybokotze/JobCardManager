namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreaIdToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "AreaId", c => c.Int());
            CreateIndex("dbo.ApplicationUsers", "AreaId");
            AddForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.ApplicationUsers", new[] { "AreaId" });
            DropColumn("dbo.ApplicationUsers", "AreaId");
        }
    }
}
