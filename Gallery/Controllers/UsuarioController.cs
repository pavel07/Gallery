using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Gallery.Models;

namespace Gallery.Controllers
{
    public class UsuarioController : Controller
    {
        private GalleryContainer db = new GalleryContainer();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            string correo = VerifyUser(login);
            if (!correo.IsEmpty())
                return RedirectToAction("Index", "Galeria",new {/* routeValues, for example: */ userEmail = correo });
            return View();
        }
        //
        // GET: /Usuario/Details/5
        public string VerifyUser(Login login)
        {
            Usuario usuario = db.Usuario.Find(login.UserName);
           
            
            if (usuario == null)
            {
               return "";
                
            }
            if (usuario.CONTRASENA.Equals(login.Password))
                return usuario.CORREO;
            return "";
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
    }
}