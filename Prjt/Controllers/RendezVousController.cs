using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Prjt.Models;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Prjt.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly ApplicationContext db;
        
        private readonly StripeSettings _stripeSettings;
        public RendezVousController(ApplicationContext db, IOptions<StripeSettings> stripeSettings)
        {
            this.db = db;
            _stripeSettings = stripeSettings.Value;
        }
// StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

        [HttpPost]
        public IActionResult Add(ModelRend rv)
        {

            //donner un objet a une session
            HttpContext.Session.SetObject("Rv", rv);
            return RedirectToAction("Paiments");
        }

        public IActionResult Paiments()
        {
              var RvDetails = HttpContext.Session.GetObject<ModelRend>("Rv");
            if (RvDetails == null)
                return RedirectToAction("Index", "Home");
            //var RvDetails = new ModelRend()
            //{
            //    ServiceId = 1
            //};
            PaymentModel payment = new PaymentModel();
            var service = db.Services.FirstOrDefault(x => x.NumS == RvDetails.ServiceId);
            if(service == null)
            {
                return RedirectToAction("Index", "Home");
            }
            payment.ServiceName = service.NomS;
            payment.MntPy = service.Prix;
            payment.NomCompletClient = RvDetails.Nom + " " + RvDetails.Prenom;
            return View(payment);
        }
        [HttpPost]
        public async Task<IActionResult> PaimentsAsync(PaymentModel payment)
        {
            var date = payment.DateExp.Split('/');
            int month, year;
            int.TryParse(date[0], out month);
            int.TryParse(date[1], out year);
            payment.Month = month;
            payment.Year = year;


            var result = await ProcessPayment.PayAsync(payment);
            if (result == "Success")
            {
                //Enregistremant des au DB

                int? id = HttpContext.Session.GetInt32("Id");
                var RvDetails = HttpContext.Session.GetObject<ModelRend>("Rv");
               
                if (RvDetails == null)
                    return RedirectToAction("Index", "Home");

                if (id == null)
                {
                    Client c = new Client()
                    {
                        Nom = RvDetails.Nom,
                        Prenom = RvDetails.Prenom,
                        Telephone = RvDetails.Telephone,
                        Email = RvDetails.Email,
                        DateNaissance = RvDetails.DateNaissance,
                        Password = RvDetails.Pwd,


                    };

                    db.Clients.Add(c);
                    db.SaveChanges();
                    id = c.Id;
                }
                RendezVous rv = new RendezVous
                {
                    Horraire = RvDetails.Horraire,
                    Date = RvDetails.DateRv,
                    Etat = "EnCours",
                    ServicesId = RvDetails.ServiceId,
                };
                db.RendezVous.Add(rv);
                db.SaveChanges();
                Payement p = new Payement()
                {
                    Prix = payment.MntPy,
                    NumCompte = payment.CardNumder,
                    ClientId = id,
                   NomClient=payment.NomCompletClient,
                    RendezVousId=rv.Id,

                };
                db.Payments.Add(p); 
                db.SaveChanges();
            


                return RedirectToAction("Success");
            }
            else
            {
                TempData["msg"] = result;
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error()
        {
            ViewBag.err = TempData["msg"] as string;
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }


        public IActionResult List()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
                return RedirectToAction("Login", "Auth");
            List<RendezVous> lists = new List<RendezVous>();
            if (id.HasValue)
            {
                lists = db.RendezVous.Include(r=>r.payement)
                    .Include(p=>p.services)
                    .Where(x=>x.payement.ClientId==id)
                    .ToList();
            }

            return View(lists);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
