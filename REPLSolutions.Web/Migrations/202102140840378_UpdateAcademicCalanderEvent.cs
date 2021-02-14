namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAcademicCalanderEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicCalanderEvents", "shop", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicCalanderEvents", "shop");
        }
    }
}
