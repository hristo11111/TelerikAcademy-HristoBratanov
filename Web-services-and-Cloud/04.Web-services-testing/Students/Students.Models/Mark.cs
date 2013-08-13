using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Students.Models
{
    public class Mark
    {
        private ICollection<Student> students;

        public Mark()
        {
            this.students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        public decimal Value { get; set; }
        public string Subject { get; set; }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
