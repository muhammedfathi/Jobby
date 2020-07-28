namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobedite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "Userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.jobs", "Userid");
            AddForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.jobs", new[] { "Userid" });
            DropColumn("dbo.jobs", "Userid");
        }
    }
}
