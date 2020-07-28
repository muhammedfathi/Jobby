namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletephoto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "userphoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "userphoto", c => c.String());
        }
    }
}
