//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbDiagramAgro
{
    using System;
    using System.Collections.Generic;
    
    public partial class View
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public View()
        {
            this.Role_View = new HashSet<Role_View>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string route { get; set; }
        public Nullable<int> module_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public Nullable<int> deleted_by { get; set; }
        public bool state { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<int> updated_by { get; set; }
    
        public virtual Module Module { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role_View> Role_View { get; set; }
    }
}
