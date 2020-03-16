using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebERP.PeruMoney.Controllers
{
    public class AgenciasController : Controller
    {
        // GET: Agencias
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Nuevo()
        {
            return View();
        }
    }
}