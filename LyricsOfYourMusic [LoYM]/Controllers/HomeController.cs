using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyricsOfYourMusic__LoYM_.Models;

namespace LyricsOfYourMusic__LoYM_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(Usuario usu)
        {
            return View(usu);
        }
        public ActionResult Registro(Usuario usu) {
            return View(usu);
        }
        public ActionResult Principal(LoYM loym) {
            return View(loym);
        }
        public ActionResult Agregar(LoYM loym) {
            return View(loym);
        }
        public ActionResult Ver(string i, LoYM loym)
        {
            ViewBag.cancion = i;
            return View(loym);
        }
        public ActionResult Modificar(string i, string c, LoYM loym)
        {
            ViewBag.cancion = i;
            ViewBag.c = c;
            return View(loym);
        }
        public ActionResult Eliminar(string i, string cnf, LoYM loym)
        {
            ViewBag.cancion = i;
            ViewBag.cnf = cnf;
            return View(loym);
        }

    }
}
