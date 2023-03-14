using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_Blog.Models;
using System.Diagnostics;

namespace MVC_Blog.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        //College colleges;



        public IActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();
            client.BaseAddress = new Uri("https://localhost:44345/");  //https://localhost:44345/api/Blog/GetBlog

            var response = client.GetAsync("api/Blog/GetBlog").Result;

            if (response.IsSuccessStatusCode)
            {
                var display = response.Content.ReadAsAsync<List<Blog>>();
                blogs = display.Result;
            }
            return View(blogs);
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