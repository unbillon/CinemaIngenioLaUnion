﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INGENIO_LA_UNIONEntities : DbContext
    {
        public INGENIO_LA_UNIONEntities()
            : base("name=INGENIO_LA_UNIONEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<asiento> asiento { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<funcion> funcion { get; set; }
        public virtual DbSet<sala> sala { get; set; }
        public virtual DbSet<ticket> ticket { get; set; }
        public virtual DbSet<ticket_asiento> ticket_asiento { get; set; }
        public virtual DbSet<tipo_sala> tipo_sala { get; set; }
    }
}