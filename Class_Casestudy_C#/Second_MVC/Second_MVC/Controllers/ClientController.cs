using Microsoft.AspNetCore.Mvc;
using Second_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Second_MVC.Controllers
{
    public class ClientController : Controller
    {
        private static List<ClientInfo> clients = new List<ClientInfo>
        {
            new ClientInfo { ClientId = 1, CompanyName = "ABC Ltd", WebUrl = "http://abc.com", Email = "info@abc.com", Category = "Software Services", Standard = "CMMI3" },
            new ClientInfo { ClientId = 2, CompanyName = "XYZ Pvt Ltd", WebUrl = "http://xyz.com", Email = "contact@xyz.com", Category = "Hardware_Support", Standard = "ISO" }
        };

        [Route("/")]  //start up
        [Route("List", Name = "List")]
        public IActionResult ShowAllClientDetails()
        {
            return View(clients);
        }

        [Route("id/{id}")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var res = clients.Where(cl => cl.ClientId.Equals(id)).FirstOrDefault();
            return View("ClientDetails",res);
        }

        [Route("name/{name}")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var res = clients.Where(cl => cl.CompanyName.Equals(name)).FirstOrDefault();
            return View("ClientDetails",res);
        }

        [Route("email/{email}")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var res = clients.Where(cl => cl.Email.Equals(email)).FirstOrDefault();
            return View("ClientDetails", res);
        }
        [Route("category/{category}")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var res = clients.Where(cl => cl.Category.Equals(category)).FirstOrDefault();
            return View("ClientDetails", res);
        }

        [Route("standard/{standard}")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var res = clients.Where(cl => cl.Standard.Equals(standard)).FirstOrDefault();
            return View("ClientDetails", res);
        }

        [Route("add")]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost("add")]
        [Route("NewAdd")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clientInfo.ClientId = clients.Count + 1;
            clients.Add(clientInfo);
            return RedirectToAction("ShowAllClientDetails");
        }
    }
}
