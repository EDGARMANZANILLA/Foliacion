﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAP.Foliacion.Negocio;
using DAP.Foliacion.Entidades;

namespace PruebaNAV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var a = PruebaDeNegocio.ObtenerTodasCuentas();

            return View();
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