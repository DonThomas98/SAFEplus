//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAFE.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class MATERIAL_CAPACITACIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIAL_CAPACITACIONES()
        {
            this.MATERIAL_SOLICITADO_ID_MAT9F2C = new HashSet<MATERIAL_SOLICITADO_ID>();
            this.MATERIAL_SOLICITADO = new HashSet<MATERIAL_SOLICITADO>();
        }
    
        public long ID { get; set; }
        public string MATERIAL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIAL_SOLICITADO_ID> MATERIAL_SOLICITADO_ID_MAT9F2C { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIAL_SOLICITADO> MATERIAL_SOLICITADO { get; set; }
    }
}
