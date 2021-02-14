namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAcademicSessionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicSessions", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AcademicSessions", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicSessions", "EndDate");
            DropColumn("dbo.AcademicSessions", "StartDate");
        }
    }
}
