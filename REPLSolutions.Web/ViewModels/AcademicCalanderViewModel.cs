using REPLSolutions.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.ViewModels
{
    public class AcademicCalanderViewModel
    {
        public AcademicCalander AcademicCalander { get; set; }
        public List<AcademicCalander> CalanderRules { get; set; }

        public int AcademicCalanderEventId { get; set; }

     //   public AcademicCalanderEvent AcademicCalanderEvent { get; set; }
        public List<AcademicCalanderEvent> AcademicCalanderEvents { get; set; }

    }
}