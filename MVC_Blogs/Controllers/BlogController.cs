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

        public IActionResult Index1()
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
        [HttpPost]
        public IActionResult Create(Blog blog)
        {

            client.BaseAddress = new Uri(URL.WebApiUrl);
            Blog blog1 = new Blog()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = DateTime.Now
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
        [HttpGet]
        public IActionResult Details(int id)   
        {
            client.BaseAddress = new Uri(URL.WebApiUrl);
            var response = client.GetAsync("api/Blog/GetByIdBlog?id=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
            }
            return View(blogs);   
        }
        
        public IActionResult Edit(int id)
        {

            client.BaseAddress = new Uri(URL.WebApiUrl);
            var response = client.GetAsync("api/Blog/GetByIdBlog?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
            }
            return View(blogs);
        }

        //[HttpPost]
        //public IActionResult Edit([FromBody] Blog blog)     
        //{
        //    client.BaseAddress = new Uri(URL.WebApiUrl);
        //    Blog blog1 = new Blog()
        //    {
        //        Id = blog.Id,
        //        Title = blog.Title,
        //        Content = blog.Content,
        //        CreatedAt = DateTime.Now
        //    };

        //    string strPayload = JsonConvert.SerializeObject(blog1);
        //    HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
        //    var response = client.PutAsJsonAsync("api/Blog/UpdateBlog", context).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}











        [HttpDelete]
        public ActionResult Delete(int id)   
        {
            client.BaseAddress = new Uri(URL.WebApiUrl);
            var response = client.DeleteAsync("api/Blog/DeleteBlog?id=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                blogs = response.Content.ReadAsAsync<Blog>().Result;
                return RedirectToAction("Index");
            }
            return View();
        }












    }
}
