using DAP.Foliacion.Datos;
using DAP.Foliacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAP.Foliacion.Negocio
{
    public class PruebaDeNegocio
    {

        public static IEnumerable<Tbl_CuentasBancarias> ObtenerTodasCuentas()
        {
            var transaccion = new Transaccion();

            var repositorio = new Repositorio<Tbl_CuentasBancarias>(transaccion);
            var nominas = repositorio.ObtenerTodos();
            return nominas;

        }











    }
}
