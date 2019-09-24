namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveManyToManyBetweenCustomerAndQuote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerQuotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerQuotes", "QuotationId", "dbo.Quotations");
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerId" });
            DropIndex("dbo.CustomerQuotes", new[] { "QuotationId" });
            AddColumn("dbo.Quotations", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quotations", "CustomerId");
            AddForeignKey("dbo.Quotations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropTable("dbo.CustomerQuotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerQuotes",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        QuotationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.QuotationId });
            
            DropForeignKey("dbo.Quotations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Quotations", new[] { "CustomerId" });
            DropColumn("dbo.Quotations", "CustomerId");
            CreateIndex("dbo.CustomerQuotes", "QuotationId");
            CreateIndex("dbo.CustomerQuotes", "CustomerId");
            AddForeignKey("dbo.CustomerQuotes", "QuotationId", "dbo.Quotations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerQuotes", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
