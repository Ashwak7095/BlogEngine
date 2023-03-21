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
                    JWT? jwt = JsonConvert.DeserializeObject<JWT>(token);
                    if (jwt.token == null)
                    {
                        ViewBag.Message = "Incorrect UserId or Password";
                        return RedirectToAction("~/Blog/Index");
                    }
                    HttpContext.Session.SetString("JWToken", jwt.token);
                }
                return Redirect("~/Blog/Index");
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
