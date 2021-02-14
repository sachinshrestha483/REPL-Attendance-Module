using REPLSolutions.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.ViewModels
{
    public class AcademicCalanderEventsIndexViewModel
    {
        public AcademicCalanderEvent AcademicCalanderEvent { get; set; }

        public List<AcademicCalanderEvent> AcademicCalanderEvents { get; set; }

    }
}