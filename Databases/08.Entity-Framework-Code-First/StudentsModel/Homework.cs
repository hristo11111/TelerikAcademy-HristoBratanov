using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudentsModel
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        [Column("Content")]
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
