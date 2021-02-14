namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalandersRule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicCalandersRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AcademicCalanderRule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicCalandersRules");
        }
    }
}
