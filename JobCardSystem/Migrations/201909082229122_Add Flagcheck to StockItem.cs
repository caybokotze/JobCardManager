namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlagchecktoStockItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockItems", "FlagCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockItems", "FlagCheck");
        }
    }
}
