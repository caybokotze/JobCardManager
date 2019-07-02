namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveManyToManyBetweenUserAndCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUserCustomers", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AppUserCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerJobCards", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerJobCards", "JobCardId", "dbo.JobCards");
            DropIndex("dbo.AppUserCustomers", new[] { "ApplicationUserId" });
            DropIndex("dbo.AppUserCustomers", new[] { "CustomerId" });
            DropIndex("dbo.CustomerJobCards", new[] { "CustomerId" });
            DropIndex("dbo.CustomerJobCards", new[] { "JobCardId" });
            AddColumn("dbo.JobCards", "CustomerId", c => c.Int(nullable: false));
            
            DropTable("dbo.AppUserCustomers");
            DropTable("dbo.CustomerJobCards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerJobCards",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.JobCardId });
            
            CreateTable(
                "dbo.AppUserCustomers",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.CustomerId });

            DropColumn("dbo.JobCards", "CustomerId");
            CreateIndex("dbo.CustomerJobCards", "JobCardId");
            CreateIndex("dbo.CustomerJobCards", "CustomerId");
            CreateIndex("dbo.AppUserCustomers", "CustomerId");
            CreateIndex("dbo.AppUserCustomers", "ApplicationUserId");
            AddForeignKey("dbo.CustomerJobCards", "JobCardId", "dbo.JobCards", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerJobCards", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppUserCustomers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AppUserCustomers", "ApplicationUserId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
        }
    }
}
