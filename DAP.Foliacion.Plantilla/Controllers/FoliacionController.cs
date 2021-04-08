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
                NuevoBanco.FormasQuincena1 = inventarioBanco.FormasQuincena1;
                NuevoBanco.FormasQuincena2 = inventarioBanco.FormasQuincena2;
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





        public ActionResult Inventario_Ajustar()
        {
            
           






            //pasar nombre de bancos activos
            List<string> nombresBancos = new List<string>();

            var InventariosActivos = Negocios.FoliacionNegocios.ObtenerInventarioActivo();

            foreach (var inventarioBanco in InventariosActivos)
            {
                string NuevoBanco;
              
                NuevoBanco = inventarioBanco.Tbl_CuentasBancarias.NombreBanco;
              

                nombresBancos.Add(NuevoBanco);
            }




            //Pasar nombre de personas activos
            List<string> nombrePersonal = new List<string>();

            var PersonalActivo = Negocios.FoliacionNegocios.ObtenerPersonalActivo();

            foreach (var unaPersona in PersonalActivo)
            {
                string NuevoNombrePersonal;

                NuevoNombrePersonal = unaPersona.NombrePersonal;

                nombresBancos.Add(NuevoNombrePersonal);
            }


            //Lista del inventario para mostrarlo en la vista
         
            List<AsignacionInventarioModel> inventarioMostrar = new List<AsignacionInventarioModel>();

            int anio = DateTime.Now.Year;
            var InventarioActivoPoranio = Negocios.FoliacionNegocios.ObtenerInventarioAnualActivo(anio);


            foreach (var inventarioUnico in InventarioActivoPoranio)
            {
                AsignacionInventarioModel NuevaAsignacionInventario = new AsignacionInventarioModel();
                NuevaAsignacionInventario.Id = inventarioUnico.Id;
                NuevaAsignacionInventario.NombreBanco = inventarioUnico.Tbl_CuentasBancarias.NombreBanco;
                NuevaAsignacionInventario.NombrePersona = inventarioUnico.Tbl_AsignacionPersonal.NombrePersonal;
                NuevaAsignacionInventario.FoliosAsignados = inventarioUnico.FoliosAsignados;
                NuevaAsignacionInventario.FolioInicial = inventarioUnico.FolioInicial;
                NuevaAsignacionInventario.FolioFinal = inventarioUnico.FolioFinal;
                NuevaAsignacionInventario.FechaAsignacion = inventarioUnico.FechaAsignacion;

                inventarioMostrar.Add(NuevaAsignacionInventario);

            }



            //Prepara la lista de modelos para un unico envio hacia la vista
            //ListaAsignancionInventarioModel mostrarModelos = new ListaAsignancionInventarioModel();
            //mostrarModelos.nombrePersonal.Add()

            







            return View();
        }








        ////////// Metodos Post ///////////////////////////

        [HttpPost]
        public JsonResult GuardarInventario(string banco, int finicial, int ffinal, int ftotal)
        {
            bool bandera = false;
            try
            {

                           int idBancoEncontrado = Negocios.FoliacionNegocios.ObtenerBanco(banco);
                 bandera = Negocios.FoliacionNegocios.GuardarFolios( idBancoEncontrado, finicial, ffinal, ftotal);
              

            }
            catch (Exception e)
            {
                bandera = false;
            }

            return Json(bandera, JsonRequestBehavior.AllowGet);
        }


    }
}