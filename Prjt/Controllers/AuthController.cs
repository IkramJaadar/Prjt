using Microsoft.AspNetCore.Mvc;
using Prjt.Models;

namespace Prjt.Controllers
{
    public class AuthController : Controller
    {

        public ApplicationContext db;
        public AuthController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Client client)
        {
            var pt = db.Clients.FirstOrDefault(m => m.Email.Equals(client.Email) && m.Password.Equals(client.Password));
            if (pt != null)
            {
                HttpContext.Session.SetInt32("id", pt.Id);
                HttpContext.Session.SetString("fullname", pt.Nom + " " + pt.Prenom);
                return RedirectToAction("List", "RendezVous");
            }
            ModelState.AddModelError("Email", "Le client n'existe pas");
            return View(client);
        }
    }
}
