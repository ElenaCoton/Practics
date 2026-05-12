using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stitch.Bll;
using Stitch.Core;
using Stitch.Core.InputModels;
using Stitch.Dal;

namespace WebAppStitch.Controllers
{
    public class KitThemesController : Controller
    {
        private readonly DataContext db;
        private readonly IWebHostEnvironment _env;
        KitRepository kitRepository;
        KitManager _kitManager;
        //public KitOutputModel kitOutModel;

        public KitThemesController(DataContext context, IWebHostEnvironment env)
        {
            db = context;
            kitRepository = new KitRepository(db);
            _kitManager = new KitManager(kitRepository);
            _env = env;
        }
        [BindProperty]
        public IFormFile? Upload { get; set; } // Для получения файла из формы

        // GET: KitThemesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: KitThemesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KitThemesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitThemesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KitThemesController/Edit/5
        public IActionResult Edit(int id)
        {
            var kitItem = db.Kit.Include(s => s.Themes).FirstOrDefault(s => s.Id == id);

            var viewModel = new KitInputModel
            {
                Id = kitItem.Id,
                Name = kitItem.Name,
                KitNumber = kitItem.KitNumber,
                ThemeCheckBoxes = db.Theme.Select(c => new ThemeCheckBoxViewModel
                {
                    Id = c.Id,
                    Title = c.Name//,
                //IsSelected = kitItem.Themes.Exists(sc => sc.Id == c.Id)
                //IsSelected = kitItem.Themes.Any(sc => sc.Id == c.Id)

            }).ToList()
            };

            foreach (var row in viewModel.ThemeCheckBoxes)
            {
                row.IsSelected = kitItem.Themes.Exists(sc => sc.Id == row.Id);
            }

                // Проверяем, есть ли уже этот курс у студента
                //IsSelected = kitItem.Themes.Any(sc => sc.Id == c.Id)
                return View(viewModel);
        }

        // POST: KitThemesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KitInputModel model)
        {
            var kitItem = db.Kit.Include(s => s.Themes).FirstOrDefault(s => s.Id == model.Id);

            if (kitItem != null)
            {
                //kitItem.Name = model.Name;
                kitItem.Themes.Clear(); // Очищаем старые связи

                // Добавляем новые связи на основе выбранных чекбоксов
                foreach (var courseBox in model.ThemeCheckBoxes.Where(c => c.IsSelected))
                {
                    var course = db.Theme.Find(courseBox.Id);
                    kitItem.Themes.Add(course);
                }

                db.SaveChanges();
                return RedirectToAction("Index","Kit"); // Перенаправление на список
            }
            return View(model);
        }

        // GET: KitThemesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KitThemesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
