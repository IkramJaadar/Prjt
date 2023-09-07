using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prjt.Models;
using System.Diagnostics;

namespace Prjt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationContext db;
        
        public HomeController(ILogger<HomeController> logger,ApplicationContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var  lst= db.Services.ToList();
            ViewBag.listServices= lst;
            List<Sliders> lstsliders = db.Sliders.ToList();
            ViewBag.listSliders = lstsliders;

            ViewBag.Services = new SelectList(db.Services.ToList(), "NumS", "NomS");
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}