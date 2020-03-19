using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebERP.PeruMoney.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
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