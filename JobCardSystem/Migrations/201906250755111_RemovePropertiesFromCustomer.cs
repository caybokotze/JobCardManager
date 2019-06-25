namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePropertiesFromCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CellNumber", c => c.String(maxLength: 11));
            DropColumn("dbo.Customers", "ActiveState");
            DropColumn("dbo.Customers", "Customer_email");
            DropColumn("dbo.Customers", "Client");
            DropColumn("dbo.Customers", "Contact_Name");
            DropColumn("dbo.Customers", "Contact_Number");
            DropColumn("dbo.Customers", "Contact_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Contact_Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Contact_Number", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Customers", "Contact_Name", c => c.String());
            AddColumn("dbo.Customers", "Client", c => c.String());
            AddColumn("dbo.Customers", "Customer_email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ActiveState", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "CellNumber");
            DropColumn("dbo.Customers", "Email");
        }
    }
}
