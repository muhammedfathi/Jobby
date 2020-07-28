namespace Jobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomeproptouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "University", c => c.String());
            AddColumn("dbo.AspNetUsers", "Faculty", c => c.String());
            AddColumn("dbo.AspNetUsers", "GraduationYear", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Workfield", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Workfield");
            DropColumn("dbo.AspNetUsers", "GraduationYear");
            DropColumn("dbo.AspNetUsers", "Faculty");
            DropColumn("dbo.AspNetUsers", "University");
        }
    }
}
