namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAttributesToStockItem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false));
        }
    }
}
