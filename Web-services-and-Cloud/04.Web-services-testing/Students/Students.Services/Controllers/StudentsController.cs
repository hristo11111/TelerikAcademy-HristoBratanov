using Students.Data;
using Students.Models;
using Students.Repositories;
using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentRepository;

        public StudentsController()
        {
            var dbContext = new StudentsProblemContext();
            this.studentRepository = new DbStudentRepository(dbContext);
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetAll()
        {
            var students = this.studentRepository.All();

            var studentModels =
                from student in students
                select new StudentModel()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade,
                    StudentSchool = new SchoolModel()
                    {
                        SchoolName = student.School.Name
                    }
                };

            return studentModels;
        }

        [HttpGet]
        public StudentModel Get(int id)
        {
            var student = this.studentRepository.All().Where(s => s.Id == id);

            if (student == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                    "There is no Student with such Id!");
                throw new HttpResponseException(errorResponse);
            }
            
            var studentModel =
                (from stud in student
                select new StudentModel()
                {
                    FirstName = stud.FirstName,
                    LastName = stud.LastName,
                    Age = stud.Age,
                    Grade = stud.Grade,
                    StudentSchool = new SchoolModel()
                    {
                        SchoolName = stud.School.Name,
                        Location = stud.School.Location
                    },
                    Marks =
                        from m in stud.Marks
                        select new MarkModel()
                        {
                            Value = m.Value,
                            Subject = m.Subject
                        }
                }).FirstOrDefault();

            return studentModel;
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetByParams(string subject, decimal value)
        {
            var students = this.studentRepository.All();

            var studentModels = students.Where(s => s.Marks.Any(m => m.Subject == subject && m.Value == value));

            var studs =
                from s in studentModels
                select new StudentModel()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                };

            return studs;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Student value)
        {
            if (value == null || value.FirstName == null || value.LastName == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                    "Posted value is null or any of its properties is null!");

                return errorResponse;
            }

            var entity = this.studentRepository.Add(value);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}