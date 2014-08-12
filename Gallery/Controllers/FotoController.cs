using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Controllers
{
    public class FotoController : Controller
    {
        private GalleryContainer db = new GalleryContainer();

        //
        // GET: /Foto/

        public ActionResult Index(int idGaleria)
        {
            var foto = db.Foto.Include(f => f.Galeria);
            return View(foto.ToList());
        }

   
        public ActionResult Create()
        {
            ViewBag.ID_GALERIA = new SelectList(db.Galeria, "ID_GALERIA", "NOMBRE");
            return View();
        }

        //
        // POST: /Foto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Foto.Add(foto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_GALERIA = new SelectList(db.Galeria, "ID_GALERIA", "NOMBRE", foto.ID_GALERIA);
            return View(foto);
        }

      
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}