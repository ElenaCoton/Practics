using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcCreditApp.Models;

namespace MvcCreditApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreditContext db;

        public HomeController(ILogger<HomeController> logger, CreditContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            //все записи о кредитах,
           // var allCredits = db.Credits.ToList<Credit>();
            //создаем свойство Credits в объекте ViewBag и присваиваем ему извлеченный список
          //  ViewBag.Credits = allCredits;
            GiveCredits();
            return View();
        }

        private void GiveCredits()
        {
            var allCredits = db.Credits.ToList<Credit>();
            ViewBag.Credits = allCredits;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            //возвращает соответствующее представление c получением всех записей о кредитах и за€вках:
            GiveCredits();
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;

            return View();
        }
        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            //принимает переданную ему в запросе POST модель newBid и добавл€ет ее в базу данных.
            newBid.bidDate = DateTime.Now;
            // ƒобавл€ем новую за€вку в Ѕƒ
            db.Bids.Add(newBid);
            // —охран€ем в Ѕƒ все изменени€
            db.SaveChanges();
            return "—пасибо, " + newBid.Name + ", за выбор нашего банка.¬аша за€вка будет рассмотрена в течении 10 дней.";
        }
    }
}
