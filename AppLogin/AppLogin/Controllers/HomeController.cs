using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLogin.Models;
using AppLogin.ViewModels;

namespace AppLogin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/{msg}")]
        public ActionResult Index(string msg)
        {
            ViewBag.ErrorMsg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios login)
        {
            var usuarios = new BaseTemporalEntities();
            
            Usuarios existe = usuarios.Usuarios.SingleOrDefault(x => x.usuario == login.usuario && x.pass == login.pass);
            if(existe == null)
            {
                return RedirectToAction("Index", new { msg = "El usuario que digito no existe"});
            }
            
            return Content(existe.correo + existe.id);
        }

        public ActionResult Main(Usuarios usuario)
        {
            return View(usuario);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}