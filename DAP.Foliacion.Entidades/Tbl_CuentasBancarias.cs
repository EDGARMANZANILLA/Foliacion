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
    
    public partial class Tbl_CuentasBancarias
    {
        public Tbl_CuentasBancarias()
        {
            this.Tbl_AsignacionInventario = new HashSet<Tbl_AsignacionInventario>();
            this.Tbl_Inventario = new HashSet<Tbl_Inventario>();
        }
    
        public int Id { get; set; }
        public string NombreBanco { get; set; }
        public string Abreviatura { get; set; }
        public string Cuenta { get; set; }
        public int IdTipoPagoCuenta { get; set; }
        public bool EstadoCuenta { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual ICollection<Tbl_AsignacionInventario> Tbl_AsignacionInventario { get; set; }
        public virtual Tbl_TipoPagoCuenta Tbl_TipoPagoCuenta { get; set; }
        public virtual ICollection<Tbl_Inventario> Tbl_Inventario { get; set; }
    }
}
