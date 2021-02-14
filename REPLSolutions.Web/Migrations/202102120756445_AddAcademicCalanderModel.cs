namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademicCalanderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicCalanders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        AcademicCalanderRule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicCalanders");
        }
    }
}
