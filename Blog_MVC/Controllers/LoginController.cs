using DataAccessLayer.AuthenticationEntities;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blog_MVC.Controllers
{

    public class LoginController : Controller
    {

        HttpClient client = new HttpClient();
        Blog blogs;
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(Login login)
        {
            
            client.BaseAddress = new Uri(URL.WebApiUrl);
            string strPayload = JsonConvert.SerializeObject(login);
            HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync(URL.Login, context).Result;

            if (response.IsSuccessStatusCode)
            {
               // blogs = response.Content.ReadAsAsync<Blog>().Result;
               string token = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("JWTtoken", token);
                return RedirectToAction("Index");
            }
            return View();
        }





        //[HttpPost]
        //public async Task<IActionResult> LoginModel()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> LoginModel(Login login)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var read = client.PostAsJsonAsync(URL.WebApiUrl + URL.Login, login);
        //        var result = read.Result;

        //        if(result.IsSuccessStatusCode)
        //        {
        //            string token = await result.Content.ReadAsStringAsync();
        //            HttpContext.Session.SetString("JWToken", token);
        //            return RedirectToAction("Index");
        //        }
        //        return View(result);
        //    }
        //}
    }
}
