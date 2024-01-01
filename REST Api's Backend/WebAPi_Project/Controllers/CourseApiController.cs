using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class CourseApiController : ApiController
    {
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCourses()
        {
            List<coursemodel> list = db.courses.Select(x => new coursemodel()
            {
                id = x.id,
                name = x.name,
                credithours = x.credithours,
                pre_requisite = x.pre_requisite

            }).ToList(); 
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCoursesById(string id)
        {
            var std = db.courses.Where(model => model.id == id).Select(x=> new coursemodel()
            {
                id = x.id,
                name = x.name,
                credithours = x.credithours,
                pre_requisite = x.pre_requisite 
            }).FirstOrDefault();
            return Ok(std);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertCourses(course s)
        {
            db.courses.Add(s);
            db.SaveChanges(); 
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult EditCourse(course  s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCourse(string id)
        {
            var std = db.courses.Where(model => model.id == id).FirstOrDefault();
            db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
            
        
    }
}