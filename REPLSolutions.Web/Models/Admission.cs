using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public int RollNumber { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }


        public ClassRoom ClassRoom { get; set; }

        public int ClassRoomId { get; set; }



    }
}