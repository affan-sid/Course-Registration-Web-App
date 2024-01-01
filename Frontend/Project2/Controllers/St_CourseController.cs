using Newtonsoft.Json;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class St_CourseController : Controller
    {
        HttpClient client = new HttpClient();
       
        public ActionResult Index()
        {
            List<registration> std_list = new List<registration>();
            client.BaseAddress = new Uri("https://localhost:44379/api/St_CourseApi");
            var response = client.GetAsync("St_CourseApi/"+ Session["StudentId"]);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<List<registration>>(data);
            }
            return View(std_list);
        }
        public ActionResult Delete(string course_id)
        {
            registration s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi/" + course_id + "/" + Session["StudentId"]);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<registration>(data);
            }
            return View(s);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string course_id)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.DeleteAsync("RegistrationApi/" + course_id + "/" + Session["StudentId"]);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","AdminLogin");
        }
    }
}