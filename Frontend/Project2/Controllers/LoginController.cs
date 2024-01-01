using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Project2.Models;
using System.Net.Http;
using System.Text;

namespace Project2.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(student s)
        {
            List<student> std_list = new List<student>();
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            var response = client.GetAsync("StudentApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<List<student>>(data);
            }
            int c = 0;
            foreach(var val in std_list)
            {
                if (val.id == s.id)
                {
                    c = 1;
                }
            }
            if (c == 1)
            {
                Session["StudentId"] = s.id;
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "St_Course");
            }
            else
            {
                ViewBag.ErrorMessage = "'Student Id is incorrect!";
                return View();
            }
            
        }
        /*
         public ActionResult Index(student s)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/LoginApi");
            string data = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
            var stud = response.Content.ReadAsStringAsync();
            if (stud != null)
            {
                Session["StudentId" ]=s.id;
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "St_Course");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Student Id or password is incorrect!')</script>";
                return View();
            }
        }*/
    }
}