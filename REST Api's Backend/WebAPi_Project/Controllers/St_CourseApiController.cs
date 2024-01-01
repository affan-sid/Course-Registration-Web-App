using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class St_CourseApiController : ApiController
    {
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudentCoursesById(string id1)
        {
            List<registrationmodel> std = db.REGISTRATIONs.Where(model => model.stud_id == id1 ).Select(x => new registrationmodel()
            {
                stud_id = id1,
                course_id = x.course_id,
                section = x.section,
                c_status = x.c_status,
                pre_requisite = x.pre_requisite
            }).ToList();
            return Ok(std);
        }
    }
}
