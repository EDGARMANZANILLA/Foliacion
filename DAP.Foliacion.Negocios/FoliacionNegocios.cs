using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP.Foliacion.Entidades;
using DAP.Foliacion.Datos;

namespace DAP.Foliacion.Negocios
{
    public class FoliacionNegocios
    {

        public static IEnumerable<Tbl_Inventario> ObtenerInventarioActivo()
        {
            var transaccion = new Transaccion();

            var repositorio = new Repositorio<Tbl_Inventario>(transaccion);

            var InventariosActivos = repositorio.ObtenerPorFiltro(x => x.Activo == true);


            return InventariosActivos;
        }


        public static int ObtenerBanco(string banco)
        {
            int idBanco = 0 ;

            var transaccion = new Transaccion();

            var repositorio = new Repositorio<Tbl_CuentasBancarias>(transaccion);

            var BancosActivos = repositorio.Obtener(x => x.NombreBanco == banco && x.Activo == true);

            if (BancosActivos != null) 
            {
                idBanco = BancosActivos.Id;
            }


            return idBanco;
        }
        



        public static bool GuardarFolios(int banco, int finial, int ffinal, int ftotal )
        {
            bool bandera = false;

            var transaccion = new Transaccion();
            var repositorio = new Repositorio<Tbl_Inventario>(transaccion);

            Tbl_Inventario inventarioModificado = repositorio.Obtener(x => x.IdCuentaBancaria == banco && x.Activo == true);

            try
            {
             
                inventarioModificado.UltimoFolioInventario = ffinal;
                inventarioModificado.FormasDisponibles += ftotal;

                if (inventarioModificado.FormasQuincena1 != null && inventarioModificado.FormasQuincena2 != null) 
                {
                    int sumaDeQuinena =  (int)inventarioModificado.FormasQuincena1 + (int)inventarioModificado.FormasQuincena2;
                    decimal nuevoEstimado = inventarioModificado.FormasDisponibles / sumaDeQuinena;
                    inventarioModificado.EstimadoMeses = nuevoEstimado;
                }



                repositorio.Modificar(inventarioModificado);
                bandera = true;


            }
        
        
            catch
            {
               
               
                bandera = false;

            }

        



         
     


            return bandera;
        }




    }
}
