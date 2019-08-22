namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerSignatureLinks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerSignatures", new[] { "CustomerId" });
            DropColumn("dbo.CustomerSignatures", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerSignatures", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerSignatures", "CustomerId");
            AddForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
