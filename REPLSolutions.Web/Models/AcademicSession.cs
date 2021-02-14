using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class AcademicSession
    {
        public int Id { get; set; }

        public string name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }



    }
}