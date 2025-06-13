using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo { ContactId = 1, FirstName = "Krish", LastName = "Sakthi", CompanyName = "ABC Ltd", EmailId = "krish@example.com", MobileNo = 9876543210, Designation = "Manager" },
            new ContactInfo { ContactId = 2, FirstName = "Jeffin", LastName = "Soloman", CompanyName = "XYZ Pvt Ltd", EmailId = "jeffin@example.com", MobileNo = 9123456780, Designation = "Consultant" },
            new ContactInfo { ContactId = 3, FirstName = "kewin", LastName = "jayaprakash", CompanyName = "WER Pvt Ltd", EmailId = "kewin@example.com", MobileNo = 9078765480, Designation = "Development" }
        };
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contactById = contacts.Where(con => con.ContactId.Equals(id)).FirstOrDefault();
            return View(contactById);
        }

        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contactInfo.ContactId = contacts.Count + 1; 
            contacts.Add(contactInfo);

 
            return RedirectToAction("ShowContacts");
        }

    }
}
