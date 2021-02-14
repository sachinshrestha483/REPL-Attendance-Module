using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPLSolutions.Web.Models
{

    public enum Gender
    {
        Male,
        Female
    }
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string  LastName { get; set; }

        public Gender Gender { get; set; }





    }
}