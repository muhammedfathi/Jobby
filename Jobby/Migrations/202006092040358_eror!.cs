namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eror : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaveJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaveJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SaveJobs", "JobId", "dbo.jobs");
            DropIndex("dbo.SaveJobs", new[] { "JobId" });
            DropIndex("dbo.SaveJobs", new[] { "UserId" });
            DropTable("dbo.SaveJobs");
        }
    }
}
