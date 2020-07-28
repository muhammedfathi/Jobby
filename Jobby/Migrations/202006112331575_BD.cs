namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "StartDate");
        }
    }
}
