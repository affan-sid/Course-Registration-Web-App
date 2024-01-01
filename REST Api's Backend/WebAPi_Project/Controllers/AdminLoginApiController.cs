using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class AdminLoginApiController : ApiController
    {
        Course_RegistrationEntities1 db = new Course_RegistrationEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult Login()
        {

            var list = db.admins.Select(x => new adminmodel()
            {
                Id = x.Id,
                password = x.password
            }).FirstOrDefault();
            return Ok(list);


            /*var stud = db.admins.Where(model => model.Id == s.Id && model.password ==s.password).Select(x => new adminmodel()
            {
                Id=x.Id,
                password=x.password
            }).FirstOrDefault();
            return Ok(stud);*/
        }
    }
}
