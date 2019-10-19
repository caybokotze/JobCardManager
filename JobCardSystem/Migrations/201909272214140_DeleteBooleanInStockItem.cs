namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteBooleanInStockItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockItems", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockItems", "Deleted");
        }
    }
}
