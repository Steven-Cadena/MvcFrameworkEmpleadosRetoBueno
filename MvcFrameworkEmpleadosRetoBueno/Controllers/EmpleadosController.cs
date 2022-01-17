using MvcFrameworkEmpleadosRetoBueno.Models;
using MvcFrameworkEmpleadosRetoBueno.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFrameworkEmpleadosRetoBueno.Controllers
{
    public class EmpleadosController : Controller
    {
        public RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo) 
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
    }
}