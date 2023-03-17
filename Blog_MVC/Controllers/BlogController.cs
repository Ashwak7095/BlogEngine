using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blog_MVC.Controllers
{
    public class BlogController : Controller
    {
        HttpClient client = new HttpClient();
        Blog blogs;

        public IActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();  

            var response = client.GetAsync(URL.WebApiUrl + URL.GetBlog).Result;
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
            Blog blog1 = new Blog()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = DateTime.Now
            };

            string strPayload = JsonConvert.SerializeObject(blog1);
            HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync(URL.WebApiUrl + URL.CreateBlog, context).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var response = client.GetAsync(URL.WebApiUrl+URL.GetByIdBlog + id).Result;
            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
            }
            return View(blogs);
        }

        public IActionResult Edit(int id)
        {
            var response = client.GetAsync(URL.WebApiUrl+URL.GetByIdBlog + id).Result;
            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
            }
            return View(blogs);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            var response = client.PutAsJsonAsync<Blog>(URL.WebApiUrl + URL.UpdateBlog, blog).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int id)
        {
            var response = client.GetAsync(URL.WebApiUrl + URL.GetByIdBlog + id).Result;
            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
            }
            return View(blogs);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)   
        {
            var response = client.DeleteAsync(URL.WebApiUrl + URL.DeleteBlog + id).Result;
            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
