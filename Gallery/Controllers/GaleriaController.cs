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
        public static string Email ;
        //
        // GET: /Galeria/

        public ActionResult Index(string userEmail)
        {
            
            Email = userEmail;
            var galeria = db.Galeria.Include(g => g.Usuario);
            Redirect("/Galeria/Index");
            return View(galeria.ToList());
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
                db.SP_INSERT_GALERIA(galeria.NOMBRE, Email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galeria);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}