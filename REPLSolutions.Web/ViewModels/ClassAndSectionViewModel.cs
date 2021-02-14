using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.ViewModels
{
    public class ClassAndSectionViewModel
    {

       

        [DisplayName("Select Class")]
        [Required]
        public int classId { get; set; }

        [DisplayName("Select Section")]
        [Required]

        public int sectionId { get; set; }


        [DisplayName("Attendance For Date")]
        [Required]

        public DateTime attendanceDate { get; set; }



    }
}