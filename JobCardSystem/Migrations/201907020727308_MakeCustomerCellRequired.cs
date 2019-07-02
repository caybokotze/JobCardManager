namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCustomerCellRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CellNumber", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CellNumber", c => c.String(maxLength: 11));
        }
    }
}
