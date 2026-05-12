using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.IRepositories;
using Stitch.Dal;

namespace WebAppStitch.Controllers
{
    public class StatusController : Controller
    {
        private readonly DataContext db;
        StatusRepository statusRepository;

        public StatusController(DataContext context)
        {
            this.db = context;
            statusRepository = new StatusRepository(db);
        }

        // GET: StatusController
        public ActionResult Index()
        {
            var listStatuses = statusRepository.GetAll();
            return View(listStatuses);
        }

        // GET: StatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StatusDto statusItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", statusItem);
                }
                statusRepository.Add(statusItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusController/Edit/5
        public ActionResult Edit(int id)
        {
            var statusItem = statusRepository.GetById(id);
            return View(statusItem);
        }

        // POST: StatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StatusDto statusItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", statusItem);
                }
                statusRepository.Update(statusItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusController/Delete/5
        public ActionResult Delete(int id)
        {
            var statusItem = statusRepository.GetById(id);
            return View(statusItem);
        }

        // POST: StatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StatusDto statusItem)
        {
            try
            {
                if (!ModelState.IsValid)
                { 
                    statusRepository.DeleteById(statusItem.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
