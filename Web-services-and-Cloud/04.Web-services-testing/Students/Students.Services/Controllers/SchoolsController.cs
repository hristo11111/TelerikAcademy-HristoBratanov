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
    public class SchoolsController : ApiController
    {
        private IRepository<School> schoolsRepository;

        public SchoolsController()
        {
            var dbContext = new StudentsProblemContext();
            this.schoolsRepository = new DbSchoolRepository(dbContext);
        }

        [HttpGet]
        public IEnumerable<SchoolModel> GetAll()
        {
            var schools = this.schoolsRepository.All();

            var schoolModels =
                from school in schools
                select new SchoolModel()
                {
                    SchoolName = school.Name,
                    Location = school.Location
                };

            return schoolModels;
        }

        [HttpGet]
        public SchoolFullModel Get(int id)
        {
            var school = this.schoolsRepository.All().Where(s => s.Id == id);

            if (school == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                    "There is no School with such Id!");
                throw new HttpResponseException(errorResponse);
            }

            var schoolFullModel =
                (from sch in school
                 select new SchoolFullModel()
                 {
                     Name = sch.Name,
                     Location = sch.Location,
                     Students =
                        from st in sch.Students
                        select new StudentModel()
                        {
                            FirstName = st.FirstName,
                            LastName = st.LastName,
                            Age = st.Age,
                            Grade = st.Grade
                        }
                 }).FirstOrDefault();

            return schoolFullModel;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]School value)
        {
            if (value == null || value.Name == null || value.Location == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Posted value is null or any of its properties is null!");

                return errorResponse;
            }

            var entity = this.schoolsRepository.Add(value);

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