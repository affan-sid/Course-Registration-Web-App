using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class LoginApiController : ApiController
    {
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(student s)
        {
            var stud = db.students.Where(model => model.id == s.id).Select(x => new studentmodel()
            {
                id = x.id,
            }).FirstOrDefault();
            return Ok(stud);
        }
        

    }
}
