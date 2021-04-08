using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaNAV.Modelos
{
    public class AsignacionInventarioModel
    {

        public int Id { get; set; }
        public string NombreBanco { get; set; }
        public string NombrePersona { get; set; }
        public int FoliosAsignados { get; set; }
        public int FolioInicial { get; set; }
        public int FolioFinal { get; set; }
        public System.DateTime FechaAsignacion { get; set; }




    }
}