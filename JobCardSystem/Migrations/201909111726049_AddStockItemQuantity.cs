namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockItemQuantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuoteItems", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.QuoteItems", "StockId", "dbo.StockItems");
            DropIndex("dbo.QuoteItems", new[] { "QuotationId" });
            DropIndex("dbo.QuoteItems", new[] { "StockId" });
            CreateTable(
                "dbo.StockItemQuantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuotationId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => t.StockItemId);
            
            DropTable("dbo.QuoteItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuoteItems",
                c => new
                    {
                        QuotationId = c.Int(nullable: false),
                        StockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuotationId, t.StockId });
            
            DropForeignKey("dbo.StockItemQuantities", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.StockItemQuantities", "QuotationId", "dbo.Quotations");
            DropIndex("dbo.StockItemQuantities", new[] { "StockItemId" });
            DropIndex("dbo.StockItemQuantities", new[] { "QuotationId" });
            DropTable("dbo.StockItemQuantities");
            CreateIndex("dbo.QuoteItems", "StockId");
            CreateIndex("dbo.QuoteItems", "QuotationId");
            AddForeignKey("dbo.QuoteItems", "StockId", "dbo.StockItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuoteItems", "QuotationId", "dbo.Quotations", "Id", cascadeDelete: true);
        }
    }
}
