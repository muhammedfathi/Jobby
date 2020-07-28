namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onmdlchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaveJobs", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.SaveJobs", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaveJobs", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.SaveJobs", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
