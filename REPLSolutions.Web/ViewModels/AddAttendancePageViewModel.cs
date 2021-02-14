using REPLSolutions.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.ViewModels
{
    public class AddAttendancePageViewModel
    {
        public List<AttendanceEntries> AttendanceEntries { get; set; }

        public ClassRoom ClassRoom { get; set; }

        public int classRoomId { get; set; }

        public DateTime AttendanceDate { get; set; }


        public string Notes { get; set; }



    }
}