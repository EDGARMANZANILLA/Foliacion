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



        

    }
}
