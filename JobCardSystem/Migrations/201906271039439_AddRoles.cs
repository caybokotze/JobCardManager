namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityUserClaims", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.IdentityUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.IdentityRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityRoles", "Discriminator");
            DropColumn("dbo.IdentityUserRoles", "Discriminator");
            DropColumn("dbo.IdentityUserClaims", "Discriminator");
        }
    }
}


//: