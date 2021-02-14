namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ClassRooms", new[] { "Class_id" });
            DropIndex("dbo.ClassRooms", new[] { "ClassId_id" });
            DropIndex("dbo.ClassRooms", new[] { "Section_id" });
            DropIndex("dbo.ClassRooms", new[] { "SectionId_id" });
            CreateIndex("dbo.ClassRooms", "Class_Id");
            CreateIndex("dbo.ClassRooms", "ClassId_Id");
            CreateIndex("dbo.ClassRooms", "Section_Id");
            CreateIndex("dbo.ClassRooms", "SectionId_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClassRooms", new[] { "SectionId_Id" });
            DropIndex("dbo.ClassRooms", new[] { "Section_Id" });
            DropIndex("dbo.ClassRooms", new[] { "ClassId_Id" });
            DropIndex("dbo.ClassRooms", new[] { "Class_Id" });
            CreateIndex("dbo.ClassRooms", "SectionId_id");
            CreateIndex("dbo.ClassRooms", "Section_id");
            CreateIndex("dbo.ClassRooms", "ClassId_id");
            CreateIndex("dbo.ClassRooms", "Class_id");
        }
    }
}
