using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> Students { get; set; }
        static Random rand = new Random();

        public StudentsController()
        {
            this.Students = new List<Student>();
            for (int i = 1; i < 15; i++)
            {
                Student student = new Student();
                student.Id = i;
                student.Name = "Student #" + i;
                student.Grade = i + rand.Next(5);

                List<Mark> marks = new List<Mark>();
                for (int j = 0; j < 4; j++)
                {
                    Mark mark = new Mark();
                    mark.Subject = "Subject #" + rand.Next(5);
                    mark.Score = j + rand.NextDouble();
                    marks.Add(mark);
                }

                student.Marks = marks;
                this.Students.Add(student);
            }
        }

        // GET api/values
        public IEnumerable<Student> Get()
        {
            return this.Students;
        }

        [ActionName("marks")]
        public IEnumerable<Mark> Get(int studentId)
        {
            var marks = this.Students.FirstOrDefault(s => s.Id == studentId).Marks;

            return marks;
        }
    }
}