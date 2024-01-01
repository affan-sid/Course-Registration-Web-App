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
    public class RegistrationController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index2", "AdminLogin");
            }
            else { 
            List<registration> std_list = new List<registration>();
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<List<registration>>(data);
            }
            return View(std_list);
        }
    }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(registration std)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(string course_id, string stud_id)
        {
            registration s = null;
            //List<REGISTRATION> s = new List<REGISTRATION>();
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi/"+course_id+"/"+stud_id);
            response.Wait();
            string data = "";
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<registration>(data);
            }
            return View(s);
        }
        
        public ActionResult Edit(string course_id, string stud_id)
        {
            registration s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi/" + course_id + "/" + stud_id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<registration>(data);
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(registration s)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            string data = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }


        public ActionResult Delete(string course_id, string stud_id)
        {
            registration s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.GetAsync("RegistrationApi/" + course_id + "/" + stud_id);
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
        public ActionResult DeleteConfirmed(string course_id, string stud_id)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/RegistrationApi");
            var response = client.DeleteAsync("RegistrationApi/" + course_id + "/" + stud_id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}