using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_Blogs.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MVC_Blogs.Controllers
{
    public class HomeController : Controller
    {


        public HttpClient client = new HttpClient();
        Blog blogs;

        public IActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();
            client.BaseAddress = new Uri("https://localhost:44345/");
            var response = client.GetAsync("api/Blog/GetBlog").Result;

            if (response.IsSuccessStatusCode)
            {
                var display = response.Content.ReadAsAsync<List<Blog>>();
                blogs = display.Result;
            }
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)   
        {

            client.BaseAddress = new Uri("https://localhost:44345/");
            Blog blog1 = new Blog()
            {
                Id= blog.Id,
                Title=blog.Title,
                Content= blog.Content,
                CreatedAt= DateTime.Now    
            };

            string strPayload = JsonConvert.SerializeObject(blog1);
            HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Blog/AddBlog", context).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index1");
            }
            return View();

        }

        public IActionResult Details(int Id)
        {

            client.BaseAddress = new Uri("https://localhost:44345/");
            var response = client.GetAsync("api/Blog/GetByIdBlog?id=" + Id).Result;

            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;

            }
            return View(blogs);   //https://localhost:44345/api/Blog/GetByIdBlog?id=17

        }











        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}