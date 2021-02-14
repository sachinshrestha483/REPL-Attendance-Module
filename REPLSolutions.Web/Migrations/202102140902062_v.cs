namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicCalanderEvents", "show", c => c.Boolean(nullable: false));
            DropColumn("dbo.AcademicCalanderEvents", "shop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcademicCalanderEvents", "shop", c => c.Boolean(nullable: false));
            DropColumn("dbo.AcademicCalanderEvents", "show");
        }
    }
}
