namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalssRoomMOdel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Class_id = c.Int(),
                        ClassId_id = c.Int(),
                        Section_id = c.Int(),
                        SectionId_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Classes", t => t.Class_id)
                .ForeignKey("dbo.Classes", t => t.ClassId_id)
                .ForeignKey("dbo.Sections", t => t.Section_id)
                .ForeignKey("dbo.Sections", t => t.SectionId_id)
                .Index(t => t.Class_id)
                .Index(t => t.ClassId_id)
                .Index(t => t.Section_id)
                .Index(t => t.SectionId_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassRooms", "SectionId_id", "dbo.Sections");
            DropForeignKey("dbo.ClassRooms", "Section_id", "dbo.Sections");
            DropForeignKey("dbo.ClassRooms", "ClassId_id", "dbo.Classes");
            DropForeignKey("dbo.ClassRooms", "Class_id", "dbo.Classes");
            DropIndex("dbo.ClassRooms", new[] { "SectionId_id" });
            DropIndex("dbo.ClassRooms", new[] { "Section_id" });
            DropIndex("dbo.ClassRooms", new[] { "ClassId_id" });
            DropIndex("dbo.ClassRooms", new[] { "Class_id" });
            DropTable("dbo.ClassRooms");
        }
    }
}
