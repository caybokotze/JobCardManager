namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtDateToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "CreatedAt");
        }
    }
}
