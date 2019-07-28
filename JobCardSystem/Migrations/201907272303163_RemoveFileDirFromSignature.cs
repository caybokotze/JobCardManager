namespace JobCardSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFileDirFromSignature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signatures", "FileDir", c => c.String());
            DropColumn("dbo.Signatures", "Dir");
            DropColumn("dbo.Signatures", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Signatures", "FileName", c => c.String(nullable: false));
            AddColumn("dbo.Signatures", "Dir", c => c.String());
            DropColumn("dbo.Signatures", "FileDir");
        }
    }
}
