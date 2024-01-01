using Newtonsoft.Json;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class CourseAddDropController : Controller
    {
        // GET: CourseAddDrop
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            string st_id = (string)Session["StudentId"];

            List<registration> s = new List<registration>();
            //List<REGISTRATION> s = new List<REGISTRATION>();
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi?id=" + st_id);
            response.Wait();
            string data = "";
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<registration>>(data);
            }


            List<course> std_list = new List<course>();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var respons = client.GetAsync("CourseApi");
            respons.Wait();
            registration std = new registration();
            ViewBag.st_id = st_id;
            test = respons.Result;
            if (test.IsSuccessStatusCode)
            {
                string data1 = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<List<course>>(data1);
            }
            foreach (registration reg in s)
            {
                int index = std_list.FindIndex(item => item.id == reg.course_id);
                if (index >= 0)
                {
                    std_list.RemoveAt(index);
                }
            }
            return View(std_list);
        }
        public ActionResult Add(string course_id)
        {
            string st_id = "";
            st_id = (string)Session["StudentId"];
            registration std = new registration();
            ViewBag.st_id = st_id;
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            var response = client.GetAsync("StudentApi?id=" + st_id);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string dat = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<student>(dat);
            }
            std.course_id = course_id;
            std.stud_id = st_id;
            std.section = s.section;
            std.c_status = null;
            std.pre_requisite = null;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage respons = client.PostAsync(client.BaseAddress, content).Result;

            if (respons.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
    }
}   