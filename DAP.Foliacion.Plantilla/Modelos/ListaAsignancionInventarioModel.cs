using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaNAV.Modelos
{
    public class ListaAsignancionInventarioModel
    {

       public List<string> nombresBancos { get; set; }

       public List<string> nombrePersonal { get; set; }

       public List<InventariosModel> InventariosAMostrar { get; set; }

       

    }
}