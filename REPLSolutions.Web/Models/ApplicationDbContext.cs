using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Admission> Admissions { get; set; }

        public DbSet<AcademicCalander> AcademicCalander { get; set; }

        public DbSet<AcademicSession> AcademicSessions { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<AttendanceEntries> AttendanceEnteries { get; set; }

        public DbSet<AcademicCalanderEvent> AcademicCalanderEvents { get; set; }









        public ApplicationDbContext()
        {

        }
    }
}