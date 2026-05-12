using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Dal;
using System;

namespace WebAppStitch.Controllers
{
    public class CanvasController : Controller
    {
        private readonly DataContext db;
        CanvasRepository canvasRep ;

        public CanvasController(DataContext context)
        {
           
            db = context;
            canvasRep = new CanvasRepository(db);
        }
       //

        // GET: CanvasController
        public ActionResult Index()
        {
            var c  = canvasRep.GetAll();
            return View(c);
        }

        // GET: CanvasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CanvasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanvasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CanvasDto canv)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", canv);
                }
                canvasRep.Add(canv);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CanvasController/Edit/5
        public ActionResult Edit(int id)
        {
            CanvasDto p = new CanvasDto();

            p = canvasRep.GetById(id);
            return View(p);
        }

        // POST: CanvasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CanvasDto canv)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", canv);
            }

           canvasRep.Update(canv);
            return RedirectToAction("Index");
        }

        // GET: CanvasController/Delete/5
        public ActionResult Delete(int id)
        {
            CanvasDto p = new CanvasDto();

            p = canvasRep.GetById(id);
           if (p == null)  return RedirectToAction("Index");
           return View(p);
        }

        // POST: CanvasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CanvasDto p)
        {
            try
            {
               canvasRep.DeleteById(p.Id);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
