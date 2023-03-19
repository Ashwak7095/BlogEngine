using DataAccessLayer.AuthenticationEntities;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Blog_MVC.Controllers
{

    public class LoginController : Controller
    {

        //HttpClient client = new HttpClient();
        //Blog blogs;
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}
        //public async Task<IActionResult> Login(Login login)
        //{

        //    client.BaseAddress = new Uri(URL.WebApiUrl);
        //    string strPayload = JsonConvert.SerializeObject(login);
        //    HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
        //    var response = client.PostAsync(URL.Login, context).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // blogs = response.Content.ReadAsAsync<Blog>().Result;
        //        string token = await response.Content.ReadAsStringAsync();
        //        HttpContext.Session.SetString("JWTtoken", token);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}





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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(URL.WebApiUrl + URL.Login, stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    //JWT jwt = JsonConvert.DeserializeObject<JWT>(token);
                    if (token == null)
                    {
                        ViewBag.Message = "Incorrect UserId or Password";
                        return RedirectToAction("~/Blog/Index");
                        //return Redirect("~/Home/Index");
                    }
                    HttpContext.Session.SetString("JWToken", token);
                }
                return Redirect("~/Blog/Index");
                //return Redirect("~/Dashboard/Index");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string strPayload = JsonConvert.SerializeObject(register);
                    HttpContent context = new StringContent(strPayload, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(URL.WebApiUrl + URL.Register, context).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return View("Login");
                    }
                }
            }
            return View();

        }

    }
}
