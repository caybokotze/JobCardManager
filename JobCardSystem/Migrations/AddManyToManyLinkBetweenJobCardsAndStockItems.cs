namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyLinkBetweenJobCardsAndStockItems : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.JobCards", new[] { "CustomerId" });
            RenameColumn(table: "dbo.JobCards", name: "CustomerId", newName: "Customer_Id");
            CreateTable(
                "dbo.JobCardCustomers",
                c => new
                    {
                        JobCardId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobCardId, t.CustomerId })
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.JobCardId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.JobCardStockItems",
                c => new
                    {
                        JobCardId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobCardId, t.StockItemId })
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.JobCardId)
                .Index(t => t.StockItemId);
            
            AlterColumn("dbo.JobCards", "Customer_Id", c => c.Int());
            CreateIndex("dbo.JobCards", "Customer_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobCardStockItems", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.JobCardStockItems", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.JobCardCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.JobCardCustomers", "JobCardId", "dbo.JobCards");
            DropIndex("dbo.JobCardStockItems", new[] { "StockItemId" });
            DropIndex("dbo.JobCardStockItems", new[] { "JobCardId" });
            DropIndex("dbo.JobCardCustomers", new[] { "CustomerId" });
            DropIndex("dbo.JobCardCustomers", new[] { "JobCardId" });
            DropIndex("dbo.JobCards", new[] { "Customer_Id" });
            AlterColumn("dbo.JobCards", "Customer_Id", c => c.Int(nullable: false));
            DropTable("dbo.JobCardStockItems");
            DropTable("dbo.JobCardCustomers");
            RenameColumn(table: "dbo.JobCards", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.JobCards", "CustomerId");
        }
    }
}
