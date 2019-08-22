namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignatureIdToJobCard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobCardCustomers", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.JobCardCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.JobCardCustomers", new[] { "JobCardId" });
            DropIndex("dbo.JobCardCustomers", new[] { "CustomerId" });
            RenameColumn(table: "dbo.JobCards", name: "Customer_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.JobCards", name: "IX_Customer_Id", newName: "IX_CustomerId");
            AddColumn("dbo.JobCards", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCards", "SignatureId", c => c.Int());
            DropTable("dbo.JobCardCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobCardCustomers",
                c => new
                    {
                        JobCardId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobCardId, t.CustomerId });
            
            DropColumn("dbo.JobCards", "SignatureId");
            DropColumn("dbo.JobCards", "LastUpdated");
            RenameIndex(table: "dbo.JobCards", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.JobCards", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.JobCardCustomers", "CustomerId");
            CreateIndex("dbo.JobCardCustomers", "JobCardId");
            AddForeignKey("dbo.JobCardCustomers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobCardCustomers", "JobCardId", "dbo.JobCards", "Id", cascadeDelete: true);
        }
    }
}
