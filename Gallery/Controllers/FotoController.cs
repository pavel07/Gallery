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

        public ActionResult Index()
        {
            var foto = db.Foto.Include(f => f.Galeria);
            return View(foto.ToList());
        }

        //
        // GET: /Foto/Details/5

        public ActionResult Details(int id = 0)
        {
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        //
        // GET: /Foto/Create

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

        //
        // GET: /Foto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_GALERIA = new SelectList(db.Galeria, "ID_GALERIA", "NOMBRE", foto.ID_GALERIA);
            return View(foto);
        }

        //
        // POST: /Foto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_GALERIA = new SelectList(db.Galeria, "ID_GALERIA", "NOMBRE", foto.ID_GALERIA);
            return View(foto);
        }

        //
        // GET: /Foto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        //
        // POST: /Foto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foto foto = db.Foto.Find(id);
            db.Foto.Remove(foto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}