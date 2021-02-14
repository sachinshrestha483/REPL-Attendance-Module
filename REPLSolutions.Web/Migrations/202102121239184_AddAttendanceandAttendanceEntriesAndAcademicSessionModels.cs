namespace REPLSolutions.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendanceandAttendanceEntriesAndAcademicSessionModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendanceEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendanceId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Present = c.Boolean(nullable: false),
                        Leave = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AttendanceId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicSessionId = c.Int(nullable: false),
                        ClassRoomId = c.Int(nullable: false),
                        AttendanceOnDate = c.DateTime(nullable: false),
                        Attendanceby = c.String(),
                        AttendanceOfDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicSessions", t => t.AcademicSessionId, cascadeDelete: true)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId, cascadeDelete: true)
                .Index(t => t.AcademicSessionId)
                .Index(t => t.ClassRoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendanceEntries", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AttendanceEntries", "AttendanceId", "dbo.Attendances");
            DropForeignKey("dbo.Attendances", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Attendances", "AcademicSessionId", "dbo.AcademicSessions");
            DropIndex("dbo.Attendances", new[] { "ClassRoomId" });
            DropIndex("dbo.Attendances", new[] { "AcademicSessionId" });
            DropIndex("dbo.AttendanceEntries", new[] { "StudentId" });
            DropIndex("dbo.AttendanceEntries", new[] { "AttendanceId" });
            DropTable("dbo.Attendances");
            DropTable("dbo.AttendanceEntries");
            DropTable("dbo.AcademicSessions");
        }
    }
}
