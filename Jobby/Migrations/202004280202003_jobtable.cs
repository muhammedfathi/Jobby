namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobs",
                c => new
                    {
                        jobID = c.Int(nullable: false, identity: true),
                        job_Name = c.String(nullable: false),
                        job_description = c.String(nullable: false),
                        job_requirments = c.String(nullable: false),
                        PostedBy = c.String(nullable: false),
                        PostedOn = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Cat_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.jobID);
            
            CreateTable(
                "dbo.jobjobcategories",
                c => new
                    {
                        job_jobID = c.Int(nullable: false),
                        jobcategory_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.job_jobID, t.jobcategory_CategoryId })
                .ForeignKey("dbo.jobs", t => t.job_jobID, cascadeDelete: true)
                .ForeignKey("dbo.jobcategories", t => t.jobcategory_CategoryId, cascadeDelete: true)
                .Index(t => t.job_jobID)
                .Index(t => t.jobcategory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobjobcategories", "jobcategory_CategoryId", "dbo.jobcategories");
            DropForeignKey("dbo.jobjobcategories", "job_jobID", "dbo.jobs");
            DropIndex("dbo.jobjobcategories", new[] { "jobcategory_CategoryId" });
            DropIndex("dbo.jobjobcategories", new[] { "job_jobID" });
            DropTable("dbo.jobjobcategories");
            DropTable("dbo.jobs");
        }
    }
}
