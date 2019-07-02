namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToStockItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockItems", "Description", c => c.String());
            AddColumn("dbo.StockItems", "QuantityAvailable", c => c.Int(nullable: false));
            AddColumn("dbo.StockItems", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.StockItems", "SellingPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockItems", "SellingPrice");
            DropColumn("dbo.StockItems", "Cost");
            DropColumn("dbo.StockItems", "QuantityAvailable");
            DropColumn("dbo.StockItems", "Description");
        }
    }
}
