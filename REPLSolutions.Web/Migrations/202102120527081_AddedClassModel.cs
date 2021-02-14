namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classes");
        }
    }
}
