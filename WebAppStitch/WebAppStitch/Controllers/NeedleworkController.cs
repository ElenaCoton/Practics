using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Dal;

namespace WebAppStitch.Controllers
{
    public class NeedleworkController : Controller
    {
        private readonly DataContext db;
        NeedleworkRepository needleRep;

        public NeedleworkController(DataContext context)
        {
            this.db = context;
            needleRep = new NeedleworkRepository(db);
        }

        // GET: NeedleworkController
        public ActionResult Index()
        {
            var listNeedleWork = needleRep.GetAll();
            return View(listNeedleWork);
        }

        // GET: NeedleworkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NeedleworkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NeedleworkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NeedleworkDto needleWork)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", needleWork);
                }
                needleRep.Add(needleWork);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeedleworkController/Edit/5
        public ActionResult Edit(int id)
        {
            var needleWork = needleRep.GetById(id);
            return View(needleWork);
        }

        // POST: NeedleworkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NeedleworkDto needleWork)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Edit", needleWork);
                }
                needleRep.Update(needleWork);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeedleworkController/Delete/5
        public ActionResult Delete(int id)
        {
            var needleWork = needleRep.GetById(id);
            return View(needleWork);
        }

        // POST: NeedleworkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NeedleworkDto needleWork)
        {
            try
            {
                needleRep.DeleteById(needleWork.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
