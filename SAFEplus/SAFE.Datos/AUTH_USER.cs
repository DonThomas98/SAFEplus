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
    
    public partial class AUTH_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTH_USER()
        {
            this.ACCOUNT_USERPROFILE = new HashSet<ACCOUNT_USERPROFILE>();
            this.AUTH_USER_GROUPS = new HashSet<AUTH_USER_GROUPS>();
            this.AUTH_USER_USER_PERMISSIONS = new HashSet<AUTH_USER_USER_PERMISSIONS>();
            this.CONTRATO = new HashSet<CONTRATO>();
            this.DJANGO_ADMIN_LOG = new HashSet<DJANGO_ADMIN_LOG>();
            this.ACCOUNT_USERPROFILE1 = new HashSet<ACCOUNT_USERPROFILE>();
            this.CONTRATO1 = new HashSet<CONTRATO>();
        }
    
        public long ID { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN { get; set; }
        public bool IS_SUPERUSER { get; set; }
        public string USERNAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public bool IS_STAFF { get; set; }
        public bool IS_ACTIVE { get; set; }
        public System.DateTime DATE_JOINED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_USERPROFILE> ACCOUNT_USERPROFILE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTH_USER_GROUPS> AUTH_USER_GROUPS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTH_USER_USER_PERMISSIONS> AUTH_USER_USER_PERMISSIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO> CONTRATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DJANGO_ADMIN_LOG> DJANGO_ADMIN_LOG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_USERPROFILE> ACCOUNT_USERPROFILE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO> CONTRATO1 { get; set; }
    }
}