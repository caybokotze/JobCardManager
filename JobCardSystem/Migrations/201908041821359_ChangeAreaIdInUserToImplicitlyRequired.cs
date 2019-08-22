namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAreaIdInUserToImplicitlyRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.ApplicationUsers", new[] { "AreaId" });
            AlterColumn("dbo.ApplicationUsers", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationUsers", "AreaId");
            AddForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.ApplicationUsers", new[] { "AreaId" });
            AlterColumn("dbo.ApplicationUsers", "AreaId", c => c.Int());
            CreateIndex("dbo.ApplicationUsers", "AreaId");
            AddForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas", "Id");
        }
    }
}
