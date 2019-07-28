namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePrimaryKeysFromPurchaseItemConfiguration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PurchaseOrderItems");
            AddColumn("dbo.PurchaseOrderItems", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PurchaseOrderItems", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PurchaseOrderItems");
            DropColumn("dbo.PurchaseOrderItems", "Id");
            AddPrimaryKey("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId", "StockItemId" });
        }
    }
}
