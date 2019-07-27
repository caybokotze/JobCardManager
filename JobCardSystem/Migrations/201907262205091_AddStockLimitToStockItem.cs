namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockLimitToStockItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockItems", "LimitWarning", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockItems", "LimitWarning");
        }
    }
}
