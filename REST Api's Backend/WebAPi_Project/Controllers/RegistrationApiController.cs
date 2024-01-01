using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class RegistrationApiController : ApiController
    {
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetRegistrations()
        {
            List<registrationmodel> list = db.REGISTRATIONs.Select(x => new registrationmodel()
            {
                stud_id = x.stud_id,
                course_id = x.course_id,
                section = x.section,
                c_status = x.c_status,
                pre_requisite = x.pre_requisite
            }).ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetRegistrationsById(string id1,string id2)
        {
            var std = db.REGISTRATIONs.Where(model => model.course_id == id1 && model.stud_id == id2).Select(x => new registrationmodel()
            {
                stud_id = x.stud_id,
                course_id = x.course_id,
                section = x.section,
                c_status = x.c_status,
                pre_requisite = x.pre_requisite
            }).FirstOrDefault();
            return Ok(std);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetRegistrationsByStudent(string id)
        {
            List<registrationmodel> std = db.REGISTRATIONs.Where(model => model.stud_id == id || model.course_id==id).Select(x => new registrationmodel()
            {
                stud_id = x.stud_id,
                course_id = x.course_id,
                section = x.section,
                c_status = x.c_status,
                pre_requisite = x.pre_requisite
            }).ToList();
            return Ok(std);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertRegistrations(REGISTRATION s)
        {
            db.REGISTRATIONs.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditRegistration(REGISTRATION s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteRegistration(string id1,string id2)
        {
            var std = db.REGISTRATIONs.Where(model => model.course_id == id1 && model.stud_id==id2).FirstOrDefault();
            db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}