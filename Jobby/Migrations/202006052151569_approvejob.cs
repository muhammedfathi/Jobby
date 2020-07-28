namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approvejob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "IsApproved");
        }
    }
}
