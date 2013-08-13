using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class StudentModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public SchoolModel StudentSchool { get; set; }

        public IEnumerable<MarkModel> Marks { get; set; }
    }
}