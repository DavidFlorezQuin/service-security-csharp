﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Health_History> Health_History { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Inventory_History> Inventory_History { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Observation> Observations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role_View> Role_View { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<View> Views { get; set; }
    }
}
