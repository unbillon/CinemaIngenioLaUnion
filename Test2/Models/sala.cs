//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sala
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sala()
        {
            this.asiento = new HashSet<asiento>();
            this.funcion = new HashSet<funcion>();
        }
    
        public int id_sala { get; set; }
        public int ubicacion { get; set; }
        public int id_tipo_sala { get; set; }
        public string nombre_sala { get; set; }
        public int numero_filas { get; set; }
        public int asientos_por_fila { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asiento> asiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcion> funcion { get; set; }
        public virtual tipo_sala tipo_sala { get; set; }
    }
}
