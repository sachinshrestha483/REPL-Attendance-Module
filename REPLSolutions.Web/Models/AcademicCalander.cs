using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{

     public enum AcademicCalanderRule
    {
        [Description("Holiday on Saturday and Sunday Between SelectedDays and Other Working Days ")]
        Holiday_on_Saturday_and_Sunday_Between_Selected_Days,
        [Description("Holiday on Saturday  Between SelectedDays and Other Working Days")]

        Holiday_on_Saturday_Between_Selected_Days,
        [Description("Holiday on  Sunday Between SelectedDays and Other Working Days")]

        Holiday_on_Sunday_Between_Selected_Days,
        [Description("Holiday on day Between SelectedDays and Other Working Days")]

        Holiday_on_Day,
        [Description("Working on  Day and Other Working Days")]

        WorkingDay_on_Day


    }
    public class AcademicCalander
    {

        public int Id { get; set; }
        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]

        public DateTime EndDate { get; set; }

        public string Note { get; set; }



        public AcademicCalanderEvent AcademicCalanderEvent{ get; set; }
        [Display(Name = "Calander Rule")]

        public int AcademicCalanderEventId { get; set; }


       public AcademicCalanderRule AcademicCalanderRule { get; set; }


        [Display(Name ="Flag it if you Want This To Override The Other Rules")]
        public bool flag { get; set; }


    }
}