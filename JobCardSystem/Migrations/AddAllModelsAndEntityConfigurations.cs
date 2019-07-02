namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllModelsAndEntityConfigurations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
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
                "dbo.Installations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Date = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActiveState = c.Boolean(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Customer_email = c.String(nullable: false),
                        Industry = c.String(),
                        Client = c.String(),
                        Contact_Name = c.String(),
                        Contact_Number = c.String(nullable: false, maxLength: 10),
                        Contact_Email = c.String(nullable: false),
                        MaintenanceContract = c.String(nullable: false),
                        ContractDuration = c.Int(nullable: false),
                        ServicesPerMonth = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        IdNumber = c.String(nullable: false, maxLength: 15),
                        AreaId = c.Int(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.JobCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        ScheduledFor = c.DateTime(nullable: false),
                        JobTotal = c.Double(nullable: false),
                        SiteLocation = c.String(nullable: false),
                        ArrivalTime = c.DateTime(),
                        DepartureTime = c.DateTime(),
                        Distance = c.Int(nullable: false),
                        JobStatusId = c.Int(nullable: false),
                        JobTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobStatus", t => t.JobStatusId, cascadeDelete: true)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId, cascadeDelete: true)
                .Index(t => t.JobStatusId)
                .Index(t => t.JobTypeId);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SupplierId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        Description = c.String(),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dir = c.String(),
                        FileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        FullAmount = c.Double(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId, cascadeDelete: true)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserCustomers",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.CustomerId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.UserJobCards",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.JobCardId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceId, t.StockItemId })
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.StockItemId);
            
            CreateTable(
                "dbo.QuoteItems",
                c => new
                    {
                        QuotationId = c.Int(nullable: false),
                        StockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuotationId, t.StockId })
                .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => t.StockId);
            
            CreateTable(
                "dbo.SupplierItems",
                c => new
                    {
                        SupplierId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierId, t.StockItemId })
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.StockItemId);
            
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseOrderId, t.StockItemId })
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.StockItemId);
            
            CreateTable(
                "dbo.UserSignatures",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        SignatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.SignatureId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Signatures", t => t.SignatureId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SignatureId);
            
            CreateTable(
                "dbo.CustomerJobCards",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.JobCardId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.CustomerPayments",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.PaymentId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentRecords", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.CustomerQuotes",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        QuotationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.QuotationId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.QuotationId);
            
            CreateTable(
                "dbo.CustomerSignatures",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        SignatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.SignatureId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Signatures", t => t.SignatureId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SignatureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Installations", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Installations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerSignatures", "SignatureId", "dbo.Signatures");
            DropForeignKey("dbo.CustomerSignatures", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerQuotes", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.CustomerQuotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerPayments", "PaymentId", "dbo.PaymentRecords");
            DropForeignKey("dbo.CustomerPayments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PaymentRecords", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.PaymentRecords", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.CustomerJobCards", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.CustomerJobCards", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.UserSignatures", "SignatureId", "dbo.Signatures");
            DropForeignKey("dbo.UserSignatures", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.PurchaseOrders", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.PurchaseOrderItems", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.SupplierItems", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.SupplierItems", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.QuoteItems", "StockId", "dbo.StockItems");
            DropForeignKey("dbo.QuoteItems", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.InvoiceItems", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserJobCards", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.UserJobCards", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.JobCards", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.JobCards", "JobStatusId", "dbo.JobStatus");
            DropForeignKey("dbo.AppUserCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AppUserCustomers", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.CustomerSignatures", new[] { "SignatureId" });
            DropIndex("dbo.CustomerSignatures", new[] { "CustomerId" });
            DropIndex("dbo.CustomerQuotes", new[] { "QuotationId" });
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerId" });
            DropIndex("dbo.CustomerPayments", new[] { "PaymentId" });
            DropIndex("dbo.CustomerPayments", new[] { "CustomerId" });
            DropIndex("dbo.CustomerJobCards", new[] { "JobCardId" });
            DropIndex("dbo.CustomerJobCards", new[] { "CustomerId" });
            DropIndex("dbo.UserSignatures", new[] { "SignatureId" });
            DropIndex("dbo.UserSignatures", new[] { "ApplicationUserId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "StockItemId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.SupplierItems", new[] { "StockItemId" });
            DropIndex("dbo.SupplierItems", new[] { "SupplierId" });
            DropIndex("dbo.QuoteItems", new[] { "StockId" });
            DropIndex("dbo.QuoteItems", new[] { "QuotationId" });
            DropIndex("dbo.InvoiceItems", new[] { "StockItemId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.UserJobCards", new[] { "JobCardId" });
            DropIndex("dbo.UserJobCards", new[] { "ApplicationUserId" });
            DropIndex("dbo.AppUserCustomers", new[] { "CustomerId" });
            DropIndex("dbo.AppUserCustomers", new[] { "ApplicationUserId" });
            DropIndex("dbo.PaymentRecords", new[] { "InvoiceId" });
            DropIndex("dbo.PaymentRecords", new[] { "PaymentTypeId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Invoices", new[] { "JobCardId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.JobCards", new[] { "JobTypeId" });
            DropIndex("dbo.JobCards", new[] { "JobStatusId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "AreaId" });
            DropIndex("dbo.Installations", new[] { "Invoice_Id" });
            DropIndex("dbo.Installations", new[] { "CustomerId" });
            DropTable("dbo.CustomerSignatures");
            DropTable("dbo.CustomerQuotes");
            DropTable("dbo.CustomerPayments");
            DropTable("dbo.CustomerJobCards");
            DropTable("dbo.UserSignatures");
            DropTable("dbo.PurchaseOrderItems");
            DropTable("dbo.SupplierItems");
            DropTable("dbo.QuoteItems");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.UserJobCards");
            DropTable("dbo.AppUserCustomers");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.PaymentRecords");
            DropTable("dbo.Signatures");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Quotations");
            DropTable("dbo.Invoices");
            DropTable("dbo.StockItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.JobTypes");
            DropTable("dbo.JobStatus");
            DropTable("dbo.JobCards");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Customers");
            DropTable("dbo.Installations");
            DropTable("dbo.ExpertiseFields");
            DropTable("dbo.Areas");
        }
    }
}
