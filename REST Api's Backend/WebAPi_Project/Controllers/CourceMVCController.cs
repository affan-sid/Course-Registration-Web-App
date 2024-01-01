using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPi_Project.Models;

namespace WebAPi_Project.Controllers
{
    public class CourceMVCController : Controller
    {
        // GET: CourceMVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<student> std_list = new List<student>();
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<student>>();
                display.Wait();
                std_list = display.Result;
            }
            return View(std_list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(student std)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.PostAsJsonAsync<student>("CourseApi",std);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(string id)
        {
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id="+id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        public ActionResult Edit(string id)
        {
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(student s)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.PutAsJsonAsync<student>("CourseApi", s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(string id)
        {
            student s = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.GetAsync("CourseApi?id=" + id);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            client.BaseAddress = new Uri("https://localhost:44379/api/CourseApi");
            var response = client.DeleteAsync("CourseApi/" + id);
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