using REPLSolutions.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.ViewModels
{
    public class ClassAndSectionListViewModel
    {

        
       
        public IEnumerable<Class> classes { get; set; }
        public IEnumerable<Section> sections { get; set; }




        public List<Attendance> Attendances { get; set; }

        public ClassAndSectionViewModel ClassAndSectionViewModel { get; set; }

    }
}