using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{
    public class AcademicCalanderEvent
    {
        public int Id { get; set; }
        
        [Required]
        public string  Name { get; set; }

        public  AcademicCalanderRule AcademicCalanderRule { get; set; }


        public bool show{ get; set; }
    }
}