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
    public class CourseController : Controller
    {
        HttpClient client = new HttpClient();
        string st_id = "";
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index1", "AdminLogin");
            }
            else
            {
                //st_id = (string)Session["StudentId"];
                //ViewBag.st_id = st_id;
                List<course> std_list = new List<course>();
                client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
                var response = client.GetAsync("CourseApi");
                response.Wait();

                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    string data = test.Content.ReadAsStringAsync().Result;
                    std_list = JsonConvert.DeserializeObject<List<course>>(data);
                }
                return View(std_list);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(course std)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(string id)
        {
            course s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<course>(data);
            }
            return View(s);
        }

        public ActionResult Edit(string id)
        {
            course s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<course>(data);
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(course s)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            string data = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(string id)
        {
            course s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<course>(data);
            }
            return View(s);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            HttpClient client = new HttpClient();
            List<registration> s = new List<registration>();
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi?id=" + id);
            response.Wait();
            string data = "";
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<registration>>(data);
            }
            foreach (registration reg in s)
            {
                if (reg.course_id == id)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
                    response = client.DeleteAsync("RegistrationApi/" + reg.course_id + "/" + reg.stud_id);
                    response.Wait();
                    test = response.Result;
                }
            }
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            response = client.DeleteAsync("CourseApi?id=" + id);
            response.Wait();

            test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}