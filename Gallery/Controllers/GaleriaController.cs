using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Controllers
{
    public class GaleriaController : Controller
    {
        private GalleryContainer db = new GalleryContainer();

        //
        // GET: /Galeria/

        public ActionResult Index(string correo)
        {
            var galeria = db.Galeria.Include(g => g.Usuario);
            return View(galeria.ToList());
        }

        //
        // GET: /Galeria/Details/5

        public ActionResult Details(int id = 0)
        {
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        //
        // GET: /Galeria/Create

        public ActionResult Create()
        {
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID_USUARIO", "NOMBRE");
            return View();
        }

        //
        // POST: /Galeria/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Galeria.Add(galeria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID_USUARIO", "NOMBRE", galeria.ID_USUARIO);
            return View(galeria);
        }

        //
        // GET: /Galeria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID_USUARIO", "NOMBRE", galeria.ID_USUARIO);
            return View(galeria);
        }

        //
        // POST: /Galeria/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galeria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID_USUARIO", "NOMBRE", galeria.ID_USUARIO);
            return View(galeria);
        }

        //
        // GET: /Galeria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        //
        // POST: /Galeria/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galeria galeria = db.Galeria.Find(id);
            db.Galeria.Remove(galeria);
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