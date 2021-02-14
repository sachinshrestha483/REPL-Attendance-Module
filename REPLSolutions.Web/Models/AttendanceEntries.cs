using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class AttendanceEntries
    {

        public int Id { get; set; }
        public Attendance Attendance { get; set; }

        public int AttendanceId { get; set; }


        public Student Student { get; set; }

        public int StudentId { get; set; }

        public bool Present { get; set; }

        // Here if In Leave Then Counted as Present ....
        public bool Leave { get; set; }









    }
}