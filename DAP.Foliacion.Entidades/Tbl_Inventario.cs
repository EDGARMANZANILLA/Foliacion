//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAP.Foliacion.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Inventario
    {
        public int Id { get; set; }
        public int IdCuentaBancaria { get; set; }
        public int FormasDisponibles { get; set; }
        public int UltimoFolioInventario { get; set; }
        public int UltimoFolioQuincena { get; set; }
        public Nullable<int> EstimadoMeses { get; set; }
        public bool Activo { get; set; }
    
        public virtual Tbl_CuentasBancarias Tbl_CuentasBancarias { get; set; }

        public virtual ICollection<Tbl_Inventario> Inventarios { get; set; }



    }
}
