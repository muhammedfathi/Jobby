namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datenotreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.jobs", "PostedOn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.jobs", "PostedOn", c => c.String(nullable: false));
        }
    }
}
