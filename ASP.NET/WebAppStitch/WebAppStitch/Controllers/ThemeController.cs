using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.IRepositories;
using Stitch.Dal;

namespace WebAppStitch.Controllers
{
    public class ThemeController : Controller
    {
        private readonly DataContext db;
        ThemeRepository themeRepository;

        public ThemeController(DataContext context)
        { 
            db = context;
            themeRepository = new ThemeRepository(db);
        }


        // GET: ThemeController
        public ActionResult Index()
        {
            var listThemes = themeRepository.GetAll();
            return View(listThemes);
        }

        // GET: ThemeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThemeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThemeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThemeDto themeItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", themeItem);
                }
                themeRepository.Add(themeItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThemeController/Edit/5
        public ActionResult Edit(int id)
        {
            var themeItem = themeRepository.GetById(id);
            return View(themeItem);
        }

        // POST: ThemeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThemeDto themeItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", themeItem);
                }
                themeRepository.Update(themeItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThemeController/Delete/5
        public ActionResult Delete(int id)
        {
            var themeItem = themeRepository.GetById(id);
            return View(themeItem);
        }

        // POST: ThemeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ThemeDto themeItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    themeRepository.DeleteById(themeItem.Id);
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
