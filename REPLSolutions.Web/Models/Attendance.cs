using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class Attendance
    {
        public int Id{ get; set; }


        public AcademicSession AcademicSession { get; set; }

        public int AcademicSessionId { get; set; }

        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }

        public DateTime AttendanceOnDate  { get; set; }

        public string Attendanceby { get; set; }

        public DateTime AttendanceOfDate { get; set; }


        public string Note { get; set; }



    }
}