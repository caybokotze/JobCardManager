namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenanceContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Services = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "MaintenanceContractId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ContractDurationId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ServicesId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ServiceContract_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MaintenanceContractId");
            CreateIndex("dbo.Customers", "ContractDurationId");
            CreateIndex("dbo.Customers", "ServiceContract_Id");
            AddForeignKey("dbo.Customers", "ContractDurationId", "dbo.ContractDurations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MaintenanceContractId", "dbo.MaintenanceContracts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "ServiceContract_Id", "dbo.ServiceContracts", "Id");
            DropColumn("dbo.Customers", "MaintenanceContract");
            DropColumn("dbo.Customers", "ContractDuration");
            DropColumn("dbo.Customers", "ServicesPerMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ServicesPerMonth", c => c.String());
            AddColumn("dbo.Customers", "ContractDuration", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MaintenanceContract", c => c.String(nullable: false));
            DropForeignKey("dbo.Customers", "ServiceContract_Id", "dbo.ServiceContracts");
            DropForeignKey("dbo.Customers", "MaintenanceContractId", "dbo.MaintenanceContracts");
            DropForeignKey("dbo.Customers", "ContractDurationId", "dbo.ContractDurations");
            DropIndex("dbo.Customers", new[] { "ServiceContract_Id" });
            DropIndex("dbo.Customers", new[] { "ContractDurationId" });
            DropIndex("dbo.Customers", new[] { "MaintenanceContractId" });
            DropColumn("dbo.Customers", "ServiceContract_Id");
            DropColumn("dbo.Customers", "ServicesId");
            DropColumn("dbo.Customers", "ContractDurationId");
            DropColumn("dbo.Customers", "MaintenanceContractId");
            DropColumn("dbo.Customers", "CreatedAt");
            DropTable("dbo.ServiceContracts");
            DropTable("dbo.MaintenanceContracts");
            DropTable("dbo.ContractDurations");
        }
    }
}
