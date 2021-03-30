using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAP.Foliacion.Negocios;
using PruebaNAV.Modelos;

namespace DAP.Foliacion.Plantilla.Controllers
{
    public class FoliacionController : Controller
    {
        // GET: Foliacion
        public ActionResult Index()
        {
            return View();
        }







        public ActionResult Inventario()
        {
            List<InventariosModel> BancosMostrar = new List<InventariosModel>();

            var InventariosActivos = Negocios.FoliacionNegocios.ObtenerInventarioActivo();
            
            foreach (var inventarioBanco in InventariosActivos)
            {
                InventariosModel NuevoBanco = new InventariosModel();
                NuevoBanco.Id = inventarioBanco.Id;
                NuevoBanco.NombreBanco = inventarioBanco.Tbl_CuentasBancarias.NombreBanco;
                NuevoBanco.FormasDisponibles = inventarioBanco.FormasDisponibles;
                NuevoBanco.UltimoFolioInventario = inventarioBanco.UltimoFolioInventario;
                NuevoBanco.UltimoFolioQuincena = inventarioBanco.UltimoFolioQuincena;
                NuevoBanco.EstimadoMeses = inventarioBanco.EstimadoMeses;

                BancosMostrar.Add(NuevoBanco);

            }

            return View(BancosMostrar);

        }


        public ActionResult Foliar()
        {
            return View();
        }


        public ActionResult Refoliar()
        {
            return View();
        }









    }
}