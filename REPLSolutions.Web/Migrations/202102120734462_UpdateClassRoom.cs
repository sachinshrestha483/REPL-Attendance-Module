namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassRoom : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassRooms", "ClassId_Id", "dbo.Classes");
            DropForeignKey("dbo.ClassRooms", "SectionId_Id", "dbo.Sections");
            DropForeignKey("dbo.ClassRooms", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.ClassRooms", "Section_Id", "dbo.Sections");
            DropIndex("dbo.ClassRooms", new[] { "Class_Id" });
            DropIndex("dbo.ClassRooms", new[] { "ClassId_Id" });
            DropIndex("dbo.ClassRooms", new[] { "Section_Id" });
            DropIndex("dbo.ClassRooms", new[] { "SectionId_Id" });
            RenameColumn(table: "dbo.ClassRooms", name: "Class_Id", newName: "ClassId");
            RenameColumn(table: "dbo.ClassRooms", name: "Section_Id", newName: "SectionId");
            AlterColumn("dbo.ClassRooms", "ClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.ClassRooms", "SectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassRooms", "ClassId");
            CreateIndex("dbo.ClassRooms", "SectionId");
            AddForeignKey("dbo.ClassRooms", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassRooms", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            DropColumn("dbo.ClassRooms", "ClassId_Id");
            DropColumn("dbo.ClassRooms", "SectionId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassRooms", "SectionId_Id", c => c.Int());
            AddColumn("dbo.ClassRooms", "ClassId_Id", c => c.Int());
            DropForeignKey("dbo.ClassRooms", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.ClassRooms", "ClassId", "dbo.Classes");
            DropIndex("dbo.ClassRooms", new[] { "SectionId" });
            DropIndex("dbo.ClassRooms", new[] { "ClassId" });
            AlterColumn("dbo.ClassRooms", "SectionId", c => c.Int());
            AlterColumn("dbo.ClassRooms", "ClassId", c => c.Int());
            RenameColumn(table: "dbo.ClassRooms", name: "SectionId", newName: "Section_Id");
            RenameColumn(table: "dbo.ClassRooms", name: "ClassId", newName: "Class_Id");
            CreateIndex("dbo.ClassRooms", "SectionId_Id");
            CreateIndex("dbo.ClassRooms", "Section_Id");
            CreateIndex("dbo.ClassRooms", "ClassId_Id");
            CreateIndex("dbo.ClassRooms", "Class_Id");
            AddForeignKey("dbo.ClassRooms", "Section_Id", "dbo.Sections", "Id");
            AddForeignKey("dbo.ClassRooms", "Class_Id", "dbo.Classes", "Id");
            AddForeignKey("dbo.ClassRooms", "SectionId_Id", "dbo.Sections", "Id");
            AddForeignKey("dbo.ClassRooms", "ClassId_Id", "dbo.Classes", "Id");
        }
    }
}
