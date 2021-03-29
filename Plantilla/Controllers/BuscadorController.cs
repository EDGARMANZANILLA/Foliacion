using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaNAV.Controllers
{
    public class BuscadorController : Controller
    {
        // GET: Buscador
     


        public ActionResult Cheques()
        {
            return View();
        }

        public ActionResult ChequesCancelados()
        {
            return View();
        }




    }
}