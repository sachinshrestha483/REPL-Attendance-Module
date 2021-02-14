namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAcademicCalander : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicCalanders", "flag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicCalanders", "flag");
        }
    }
}
