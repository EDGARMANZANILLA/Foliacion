using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaNAV.Modelos
{
    public class InventariosModel
    {


        public int Id { get; set; }

        public string NombreBanco { get; set; }

        public int FormasDisponibles { get; set; }

        public int UltimoFolioInventario { get; set; }

        public int UltimoFolioQuincena { get; set; }

        public Nullable<int> EstimadoMeses { get; set; }

    }
}