namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeleteToSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Delete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "Delete");
        }
    }
}
