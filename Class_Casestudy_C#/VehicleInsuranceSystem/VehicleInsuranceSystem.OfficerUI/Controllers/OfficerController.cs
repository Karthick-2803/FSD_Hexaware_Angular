using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using VehicleInsuranceSystem.OfficerUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace VehicleInsuranceSystem.OfficerUI.Controllers
{
    public class OfficerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public OfficerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7294/api/auth/login", model);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid login";
                return View(model);
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);
            string token = result.token;

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Email),
            new Claim(ClaimTypes.Role, "Officer"),
            new Claim("AccessToken", token)
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var token = GetToken();
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:7294/api/officer/proposals");
            var json = await response.Content.ReadAsStringAsync();

            var proposals = JsonConvert.DeserializeObject<List<ProposalViewModel>>(json);
            return View(proposals);
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            var token = GetToken();
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await client.PutAsync($"https://localhost:7294/api/officer/proposal/approve/{id}", null);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {
            var token = GetToken();
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await client.PutAsync($"https://localhost:7294/api/officer/proposal/reject/{id}", null);
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        private string GetToken() =>
            User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value;

    }
}
