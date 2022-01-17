using MvcFrameworkEmpleadosRetoBueno.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFrameworkEmpleadosRetoBueno.Data
{
    public class EmpleadosContext: DbContext
    {
        public EmpleadosContext() : base(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=Hospital;Persist Security Info=True;User ID=SA;Password=MCSD2021") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            Database.SetInitializer<EmpleadosContext>(null);
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}