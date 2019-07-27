namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAmountOfItemFromPurchaseOrderEntity : DbMigration
    {
        public override void Up()
        {
            /*
             * Drop the many to many relationships between a user and a signature, and a customer and a signature.
             * A user and customer should not be allowed to have more than one signature.
             * We are also adding a AmountOfItems number to our custom many to many configurations table.
             * Remove the AmountOfItems from the purchase order table itself.
             */

            DropForeignKey("dbo.UserSignatures", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserSignatures", "SignatureId", "dbo.Signatures");
            DropForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerSignatures", "SignatureId", "dbo.Signatures");
            DropIndex("dbo.UserSignatures", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserSignatures", new[] { "SignatureId" });
            DropIndex("dbo.CustomerSignatures", new[] { "CustomerId" });
            DropIndex("dbo.CustomerSignatures", new[] { "SignatureId" });
            AddColumn("dbo.PurchaseOrderItems", "AmountOfItems", c => c.Int(nullable: false));
            AddColumn("dbo.Signatures", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Signatures", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Signatures", "CustomerId");
            CreateIndex("dbo.Signatures", "ApplicationUserId");
            AddForeignKey("dbo.Signatures", "ApplicationUserId", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.Signatures", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.PurchaseOrders", "Quantity");
            DropTable("dbo.UserSignatures");
            DropTable("dbo.CustomerSignatures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerSignatures",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        SignatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.SignatureId });
            
            CreateTable(
                "dbo.UserSignatures",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        SignatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.SignatureId });
            
            AddColumn("dbo.PurchaseOrders", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Signatures", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Signatures", "ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.Signatures", new[] { "ApplicationUserId" });
            DropIndex("dbo.Signatures", new[] { "CustomerId" });
            DropColumn("dbo.Signatures", "ApplicationUserId");
            DropColumn("dbo.Signatures", "CustomerId");
            DropColumn("dbo.PurchaseOrderItems", "AmountOfItems");
            CreateIndex("dbo.CustomerSignatures", "SignatureId");
            CreateIndex("dbo.CustomerSignatures", "CustomerId");
            CreateIndex("dbo.UserSignatures", "SignatureId");
            CreateIndex("dbo.UserSignatures", "ApplicationUserId");
            AddForeignKey("dbo.CustomerSignatures", "SignatureId", "dbo.Signatures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserSignatures", "SignatureId", "dbo.Signatures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserSignatures", "ApplicationUserId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
        }
    }
}
