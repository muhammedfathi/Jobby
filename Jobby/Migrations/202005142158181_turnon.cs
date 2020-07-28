namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turnon : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AppliedUsers");
            AlterColumn("dbo.AppliedUsers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AppliedUsers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AppliedUsers");
            AlterColumn("dbo.AppliedUsers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AppliedUsers", "Id");
        }
    }
}
