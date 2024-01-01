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
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin s)
        {
            admin std_list = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/AdminLoginApi");
            var response = client.GetAsync("AdminLoginApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<admin>(data);
            }
            int c = 0;
            if (std_list.id == s.id && std_list.password==s.password)
            {
                Session["admin"] = "admin";
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                ViewBag.ErrorMessage = "Admin Id or password is incorrect!";
                return View();
            }

            /*client.BaseAddress = new Uri("https://localhost:44379/api/AdminLoginApi");
            string data = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
            var stud = response.Content.ReadAsStringAsync();
            if (s.id=="admin"&&s.password=="admin")
            {
                Session["admin"] = "admin";
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                ViewBag.ErrorMessage = "Admin Id or password is incorrect!";
                return View();
            }*/
        }
        public ActionResult Index1()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index1(admin s)
        {
            admin std_list = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/AdminLoginApi");
            var response = client.GetAsync("AdminLoginApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<admin>(data);
            }
            int c = 0;
            if (std_list.id == s.id && std_list.password == s.password)
            {
                Session["admin"] = "admin";
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                ViewBag.ErrorMessage = "Admin Id or password is incorrect!";
                return View("Index");
            }
        }
        public ActionResult Index2()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index2(admin s)
        {
            admin std_list = null;
            client.BaseAddress = new Uri("https://localhost:44379/api/AdminLoginApi");
            var response = client.GetAsync("AdminLoginApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                string data = test.Content.ReadAsStringAsync().Result;
                std_list = JsonConvert.DeserializeObject<admin>(data);
            }
            int c = 0;
            if (std_list.id == s.id && std_list.password == s.password)
            {
                Session["admin"] = "admin";
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                ViewBag.ErrorMessage = "Admin Id or password is incorrect!";
                return View("Index");
            }
        }
    }
}