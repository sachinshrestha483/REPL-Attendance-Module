namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updating_AcademicCalanderTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AcademicCalandersRules", newName: "AcademicCalanderEvents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AcademicCalanderEvents", newName: "AcademicCalandersRules");
        }
    }
}
