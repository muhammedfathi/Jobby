namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isapplied : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppliedUsers", "IsApplied", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppliedUsers", "IsApplied");
        }
    }
}
