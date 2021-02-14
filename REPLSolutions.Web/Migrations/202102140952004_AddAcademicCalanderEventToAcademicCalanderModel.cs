namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademicCalanderEventToAcademicCalanderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicCalanders", "AcademicCalanderEventId", c => c.Int(nullable: false));
            CreateIndex("dbo.AcademicCalanders", "AcademicCalanderEventId");
            AddForeignKey("dbo.AcademicCalanders", "AcademicCalanderEventId", "dbo.AcademicCalanderEvents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicCalanders", "AcademicCalanderEventId", "dbo.AcademicCalanderEvents");
            DropIndex("dbo.AcademicCalanders", new[] { "AcademicCalanderEventId" });
            DropColumn("dbo.AcademicCalanders", "AcademicCalanderEventId");
        }
    }
}
