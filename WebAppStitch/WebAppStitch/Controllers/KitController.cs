using System.IO;
using System.IO.Pipes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Stitch.Bll;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.InputModels;
using Stitch.Core.IRepositories;
using Stitch.Core.OutputModels;
using Stitch.Dal;


namespace WebAppStitch.Controllers
{
    public class KitController : Controller
    {
        private readonly DataContext db;
        private readonly IWebHostEnvironment _env;
        KitRepository kitRepository;
        KitManager _kitManager;
        //public KitOutputModel kitOutModel;

        public KitController(DataContext context, IWebHostEnvironment env)
        { 
            db = context;
            kitRepository = new KitRepository(db);
            _kitManager = new KitManager(kitRepository);
            _env = env;
        }

        [BindProperty]
        public IFormFile? Upload { get; set; } // Для получения файла из формы

        // GET: KitController
        public ActionResult Index(string? searchKitName, int? searchManufId, string? searchKitNumber)
        {
            var items = db.Manufacturer.ToList();
            // 2. Создаем SelectList: (Список, Значение, Текст, ВыбранноеЗначение)
            ViewBag.ManufacturerList = new SelectList(items, "Id", "Name", searchManufId);

            // var model = _kitManager.GetAll();
            var model = _kitManager.Search(searchKitName, searchManufId, searchKitNumber, null);
            return View(model);
        }

        public IActionResult ExportToPdf()
        {
            var model = _kitManager.GetAll();
            // Установка пути к папке с wkhtmltopdf.exe
            // ViewAsPdf берет представление "Index" и конвертирует его
            return new ViewAsPdf("Index", model)
            {
                FileName = "ListReport.pdf" // Имя файла для скачивания
            };
        }

        // GET: KitController/Details/5
        // public ActionResult Details(KitOutputModel model)
        public ActionResult Details(int id)
        {
            var model = _kitManager.GetById(id);
            if (model == null) return View();
            return View(model);
        }

        // GET: KitController/Create
        [HttpGet]
        public IActionResult Create()
        {
            // 1. Получаем данные для списка
            var canvasList = db.Canvas.ToList();
            var needleWorkList = db.Needlework.ToList();
            var manufacturerList = db.Manufacturer.ToList();
            var statusList = db.Status.ToList();

            // 2. Создаем SelectList: 
            // (список, значение_ключа, отображаемое_имя)
            ViewBag.CanvasId = new SelectList(canvasList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.NeedleworkId = new SelectList(needleWorkList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.ManufactureId = new SelectList(manufacturerList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.StatusId = new SelectList(statusList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            return View();
        }

        // POST: KitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KitDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", model);
                }
                if  (Upload != null)
                {
                    // 1. Формируем уникальное имя файла
                    // Генерируем уникальное имя файла
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Upload.FileName);
                    var fileRoute = Path.Combine(_env.WebRootPath, "images", "kitpictures", fileName);

                    // 2. Сохраняем файл на сервер
                    using (var fileStream = new FileStream(fileRoute, FileMode.Create))
                    {
                        await Upload.CopyToAsync(fileStream);
                    }

                    // 3. Записываем путь в базу данных
                    model.ImageLink = "/images/kitpictures/" + fileName;
                }
                //kitRepository.Add(model);
                db.Kit.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Если ошибка, пересоздаем список
                //ViewBag.CanvasId = new SelectList(db.Canvas, "Id", "Name", model.CanvasId);
                return View();
            }
        }

        // GET: KitController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kitModel = db.Kit.Include(s => s.Themes).FirstOrDefault(s => s.Id == id); 
            //_kitManager.GetInputModelById(id);
            // 1. Получаем данные для списка
            var canvasList = db.Canvas.ToList();
            var needleWorkList = db.Needlework.ToList();
            var manufacturerList = db.Manufacturer.ToList();
            var statusList = db.Status.ToList();

            // 2. Создаем SelectList: 
            // (список, значение_ключа, отображаемое_имя)
            ViewBag.CanvasId = new SelectList(canvasList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.NeedleworkId = new SelectList(needleWorkList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.ManufactureId = new SelectList(manufacturerList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });
            ViewBag.StatusId = new SelectList(statusList, "Id", "Name").
                       Prepend(new SelectListItem { Text = "-- Не выбрано --", Value = "" });


            var viewModel = new KitInputModel
            {
                Id = kitModel.Id,
                Name = kitModel.Name,
                KitNumber = kitModel.KitNumber,
                ManufactureId = kitModel.ManufactureId,
                ImageLink = kitModel.ImageLink,
                CanvasId = kitModel.CanvasId,
                NeedleworkId = kitModel.NeedleworkId,
                StatusId = kitModel.StatusId,
                Complexity = kitModel.Complexity,
                ColorNumber = kitModel.ColorNumber,
                XCount = kitModel.XCount,
                YCount = kitModel.YCount,
                Quantity = kitModel.Quantity,
                EndDate = kitModel.EndDate,
                StoragePlace = kitModel.StoragePlace,
                Description = kitModel.Description,
                ThemeCheckBoxes = db.Theme.Select(c => new ThemeCheckBoxViewModel
                {
                    Id = c.Id,
                    Title = c.Name//,
                                  //IsSelected = kitItem.Themes.Any(sc => sc.Id == c.Id)

                }).ToList()
            };


            foreach (var row in viewModel.ThemeCheckBoxes)
            {
                row.IsSelected = kitModel.Themes.Exists(sc => sc.Id == row.Id);
            }


            return View(viewModel);
        }

        // POST: KitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult  Edit(KitInputModel model)
        {
            try
            {
               /* if (!ModelState.IsValid)
                {
                    return View("Edit", model);
                }*/

                var kitItem = db.Kit.Include(s => s.Themes).FirstOrDefault(s => s.Id == model.Id);

                if (kitItem != null)
                {
                    kitItem.Name = model.Name;
                    kitItem.Themes.Clear(); // Очищаем старые связи

                    // Добавляем новые связи на основе выбранных чекбоксов
                    foreach (var courseBox in model.ThemeCheckBoxes.Where(c => c.IsSelected))
                    {
                        var course = db.Theme.Find(courseBox.Id);
                        kitItem.Themes.Add(course);
                    }

                    if (Upload != null)
                    {
                        // 1. Формируем уникальное имя файла
                        // Генерируем уникальное имя файла
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Upload.FileName);
                        var fileRoute = Path.Combine(_env.WebRootPath, "images", "kitpictures", fileName);

                        // 2. Сохраняем файл на сервер
                        using (var fileStream = new FileStream(fileRoute, FileMode.Create))
                        {
                            Upload.CopyTo(fileStream);  
                               // CopyToAsync(fileStream);
                        }

                        // 3. Записываем путь в базу данных
                        model.ImageLink = "/images/kitpictures/" + fileName;
                    }
                }
                _kitManager.Update(model);
                  //public void Update(KitInputModel kitInp)
                //db.Kit.Update(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KitController/Delete/5
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
