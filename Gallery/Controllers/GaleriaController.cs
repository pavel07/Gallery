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
            var galeria2=new List<Galeria>();
            Redirect("/Galeria/Index");
            foreach (var g in galeria)
            {
                if (g.CORREO == Email)
                {
                    galeria2.Add(g);
                }
            }
            return View(galeria2);
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

<<<<<<< HEAD
        public ActionResult Ir_Fotos(int IdGaleria)
        {
            return RedirectToAction("Index", "Foto", new {/* routeValues, for example: */ idGaleria =IdGaleria  });
        }
=======
      
>>>>>>> 4781a9fe508d85061cceef2919adeeed61477838
    }
}