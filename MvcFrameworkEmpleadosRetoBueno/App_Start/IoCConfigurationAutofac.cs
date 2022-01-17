using Autofac;
using Autofac.Integration.Mvc;
using MvcFrameworkEmpleadosRetoBueno.Data;
using MvcFrameworkEmpleadosRetoBueno.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcFrameworkEmpleadosRetoBueno.App_Start
{
    public class IoCConfigurationAutofac
    {
        public static void ConfigureDependencies() 
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(z => new EmpleadosContext()).InstancePerRequest();
            builder.RegisterType<RepositoryEmpleados>().InstancePerRequest();
            //COMO ESTAMOS EN ENTORNO MVC DEBEMOS TAMBIEN 
            //REGISTRAR TODOS LOS CONTROLADORES
            //POEMOS HACERLO UNO A UNO (PERO SI TENEMOS 1000 BUUFFF)
            //de esta forma llamamos a todos los controladores
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //TODAS LAS CLASES GENERADAS SE ALMACENAN EN UNA INTERFACE CONTAINER 
            IContainer container = builder.Build();
            //INDICAMOS A LA APP QUE UTILIZAREMOS ESTE CONTENEDOR PARA LAS DEPENDENCIAS
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}