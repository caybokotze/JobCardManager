namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveManyToManyAndAddQuotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobCardStockItems", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.JobCardStockItems", "StockItemId", "dbo.StockItems");
            DropIndex("dbo.JobCardStockItems", new[] { "JobCardId" });
            DropIndex("dbo.JobCardStockItems", new[] { "StockItemId" });
            AddColumn("dbo.JobCards", "QuotationId", c => c.Int());
            CreateIndex("dbo.JobCards", "QuotationId");
            AddForeignKey("dbo.JobCards", "QuotationId", "dbo.Quotations", "Id");
            DropTable("dbo.JobCardStockItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobCardStockItems",
                c => new
                    {
                        JobCardId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobCardId, t.StockItemId });
            
            DropForeignKey("dbo.JobCards", "QuotationId", "dbo.Quotations");
            DropIndex("dbo.JobCards", new[] { "QuotationId" });
            DropColumn("dbo.JobCards", "QuotationId");
            CreateIndex("dbo.JobCardStockItems", "StockItemId");
            CreateIndex("dbo.JobCardStockItems", "JobCardId");
            AddForeignKey("dbo.JobCardStockItems", "StockItemId", "dbo.StockItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobCardStockItems", "JobCardId", "dbo.JobCards", "Id", cascadeDelete: true);
        }
    }
}
