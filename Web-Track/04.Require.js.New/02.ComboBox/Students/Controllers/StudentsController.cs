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
                student.Age = i + rand.Next(5);
                student.AvatarUrl = @"http://www.manager.bg/sites/default/files/news_photos/avatar-james-cameron-4122797pxiva.jpg";

                this.Students.Add(student);
            }

            
        }

        // GET api/values
        public IEnumerable<Student> Get()
        {
            return this.Students;
        }

        public Student Get(int studentId)
        {
            var student = this.Students.FirstOrDefault(s => s.Id == studentId);

            return student;
        }
    }
}