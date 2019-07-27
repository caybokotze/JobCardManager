namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLinkBetweenPurchaseOrderAndUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.PurchaseOrders", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.PurchaseOrders", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.PurchaseOrders", "ApplicationUser_Id");
            AddForeignKey("dbo.PurchaseOrders", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
        }
    }
}
