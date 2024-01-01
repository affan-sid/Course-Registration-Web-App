using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class StudentApiController : ApiController
    {
        // GET: StudentApi
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudents()
        {
            List<studentmodel> list = db.students.Select(x=> new studentmodel()
            {
                id= x.id,
                fname = x.fname,
                depart = x.depart,
                student_batch = x.student_batch,
                current_sem = x.current_sem,
                gender= x.gender,
                email=x.email,
                contact_number = x.contact_number,
                section = x.section,
                cgpa = x.cgpa
            }).ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudentsById(string id)
        {
            var std = db.students.Where(model => model.id == id).Select(x => new studentmodel()
            {
                id = x.id,
                fname = x.fname,
                depart = x.depart,
                student_batch = x.student_batch,
                current_sem = x.current_sem,
                gender = x.gender,
                email = x.email,
                contact_number = x.contact_number,
                section = x.section,
                cgpa = x.cgpa
            }).FirstOrDefault();
            return Ok(std);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudents(student s)
        {
            db.students.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditStudent(student s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteStudent(string id)
        {
            var std = db.students.Where(model => model.id == id).FirstOrDefault();
            db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
        
    }
}