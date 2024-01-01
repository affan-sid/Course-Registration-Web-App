using Newtonsoft.Json;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
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
                return View(std_list);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(student std)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
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
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            var response = client.GetAsync("StudentApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<student>(data);
            }
            return View(s);
        }

        public ActionResult Edit(string id)
        {
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            var response = client.GetAsync("StudentApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<student>(data);
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(student s)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
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
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            var response = client.GetAsync("StudentApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<student>(data);
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
                if(reg.stud_id == id)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
                    response = client.DeleteAsync("RegistrationApi/" + reg.course_id + "/" + reg.stud_id);
                    response.Wait();
                    test = response.Result;
                }
            }
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/StudentApi");
            response = client.DeleteAsync("StudentApi?id=" + id);
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