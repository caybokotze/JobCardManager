namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotaionRequiredForContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CellNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CellNumber", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
