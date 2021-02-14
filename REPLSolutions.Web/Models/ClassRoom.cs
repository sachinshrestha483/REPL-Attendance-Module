using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }

        public Section Section { get; set; }

        public int SectionId { get; set; }




    }
}