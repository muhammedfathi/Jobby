namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.jobs", new[] { "Userid" });
            AddColumn("dbo.jobs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.jobs", "Userid", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.jobs", "Userid");
            CreateIndex("dbo.jobs", "ApplicationUser_Id");
            AddForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.jobs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.jobs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.jobs", new[] { "Userid" });
            AlterColumn("dbo.jobs", "Userid", c => c.String(maxLength: 128));
            DropColumn("dbo.jobs", "ApplicationUser_Id");
            CreateIndex("dbo.jobs", "Userid");
            AddForeignKey("dbo.jobs", "Userid", "dbo.AspNetUsers", "Id");
        }
    }
}
