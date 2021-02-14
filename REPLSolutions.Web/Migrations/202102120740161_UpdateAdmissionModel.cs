namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdmissionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admissions", "ClassRoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admissions", "ClassRoomId");
            AddForeignKey("dbo.Admissions", "ClassRoomId", "dbo.ClassRooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admissions", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.Admissions", new[] { "ClassRoomId" });
            DropColumn("dbo.Admissions", "ClassRoomId");
        }
    }
}
