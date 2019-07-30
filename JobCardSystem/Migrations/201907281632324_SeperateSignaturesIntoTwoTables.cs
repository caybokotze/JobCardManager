namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeperateSignaturesIntoTwoTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Signatures", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Signatures", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Signatures", new[] { "CustomerId" });
            DropIndex("dbo.Signatures", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.ApplicationUserSignatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileDir = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.CustomerSignatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileDir = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            DropTable("dbo.Signatures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileDir = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ApplicationUserSignatures", "ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.CustomerSignatures", new[] { "CustomerId" });
            DropIndex("dbo.ApplicationUserSignatures", new[] { "ApplicationUserId" });
            DropTable("dbo.CustomerSignatures");
            DropTable("dbo.ApplicationUserSignatures");
            CreateIndex("dbo.Signatures", "ApplicationUserId");
            CreateIndex("dbo.Signatures", "CustomerId");
            AddForeignKey("dbo.Signatures", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Signatures", "ApplicationUserId", "dbo.ApplicationUsers", "Id");
        }
    }
}
