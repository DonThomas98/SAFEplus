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
    
    public partial class MATERIAL_SOLICITADO_ID
    {
        public long ID { get; set; }
        public long MATERIALSOLICITADO_ID { get; set; }
        public long MATERIALCAPACITACIONES_ID { get; set; }
    
        public virtual MATERIAL_CAPACITACIONES MATERIAL_CAPACITACIONES { get; set; }
        public virtual MATERIAL_SOLICITADO MATERIAL_SOLICITADO { get; set; }
    }
}