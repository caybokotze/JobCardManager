namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApprovalRequestAndIsValid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotations", "Approve", c => c.Boolean(nullable: false));
            AddColumn("dbo.Quotations", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "IsActive");
            DropColumn("dbo.Quotations", "Approve");
        }
    }
}
