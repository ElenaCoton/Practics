using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stitch.Bll;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.OutputModels;
using Stitch.Dal;

namespace WebAppStitch.Controllers
{
    public class ManufacturerController : Controller
    {

        static List<ManufacturerOutputModel> manufacturers = new List<ManufacturerOutputModel>();
        static List<ManufacturerDto> manufacturersDto = new List<ManufacturerDto>();

        private readonly DataContext db;
        ManufacturerRepository manufacturerRep;
        ManufacturerManager manufManag;


        public ManufacturerController(DataContext context)
        {

            db = context;
            manufacturerRep = new ManufacturerRepository(db);
            manufManag = new ManufacturerManager(manufacturerRep);
            MapsterConfig.SetConfig();
        }

        // GET: ManufacturerController
        public ActionResult Index()
        {
           // MapsterConfig.SetConfig();

            manufacturers = manufManag.GetAll();

            return View(manufacturers);
        }

        // GET: ManufacturerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManufacturerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerDto m)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", m);
                }
               manufacturerRep.Add(m);
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManufacturerController/Edit/5
        public ActionResult Edit(int id)
        {
            ManufacturerDto m = new ManufacturerDto();

            m = manufacturerRep.GetById(id);
            return View(m);
        }

        // POST: ManufacturerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManufacturerDto m)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", m);
                }

                manufacturerRep.Update(m);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManufacturerController/Delete/5
        public ActionResult Delete(int id)
        {
            ManufacturerDto m = new ManufacturerDto();

            m = manufacturerRep.GetById(id);
            if (m == null) return RedirectToAction("Index");
            return View(m);
        }

        // POST: ManufacturerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ManufacturerDto m)
        {
            try
            {
                //добавить проверку, что нет наборов по данному производителю 
                manufacturerRep.DeleteById(m.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
