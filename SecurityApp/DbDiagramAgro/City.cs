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
    
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            this.People = new HashSet<Person>();
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Nullable<int> municipality_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public Nullable<int> deleted_by { get; set; }
        public bool state { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<int> updated_by { get; set; }
    
        public virtual Municipality Municipality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }
}