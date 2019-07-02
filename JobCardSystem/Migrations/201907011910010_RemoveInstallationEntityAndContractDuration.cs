namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInstallationEntityAndContractDuration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ContractDurationId", "dbo.ContractDurations");
            DropForeignKey("dbo.Installations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Installations", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.Customers", new[] { "ContractDurationId" });
            DropIndex("dbo.Installations", new[] { "CustomerId" });
            DropIndex("dbo.Installations", new[] { "Invoice_Id" });
            AddColumn("dbo.Customers", "Surname", c => c.String());
            AddColumn("dbo.MaintenanceContracts", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "ContractDurationId");
            DropTable("dbo.ContractDurations");
            DropTable("dbo.ExpertiseFields");
            DropTable("dbo.Installations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Installations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Date = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpertiseFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldExpertise = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "ContractDurationId", c => c.Int(nullable: false));
            DropColumn("dbo.MaintenanceContracts", "Duration");
            DropColumn("dbo.Customers", "Surname");
            CreateIndex("dbo.Installations", "Invoice_Id");
            CreateIndex("dbo.Installations", "CustomerId");
            CreateIndex("dbo.Customers", "ContractDurationId");
            AddForeignKey("dbo.Installations", "Invoice_Id", "dbo.Invoices", "Id");
            AddForeignKey("dbo.Installations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "ContractDurationId", "dbo.ContractDurations", "Id", cascadeDelete: true);
        }
    }
}
