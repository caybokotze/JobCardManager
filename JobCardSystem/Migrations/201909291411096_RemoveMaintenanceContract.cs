namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMaintenanceContract : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MaintenanceContractId", "dbo.MaintenanceContracts");
            DropIndex("dbo.Customers", new[] { "MaintenanceContractId" });
            DropColumn("dbo.Customers", "MaintenanceContractId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MaintenanceContractId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MaintenanceContractId");
            AddForeignKey("dbo.Customers", "MaintenanceContractId", "dbo.MaintenanceContracts", "Id", cascadeDelete: true);
        }
    }
}
