using DataAccessLayer.AuthenticationEntities;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MVC_Blogs.Controllers
{
    public class BlogController : Controller
    {

        HttpClient client = new HttpClient();
        Blog blogs;

        public IActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();
            client.BaseAddress = new Uri(URL.WebApiUrl);
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
        












    }
}
