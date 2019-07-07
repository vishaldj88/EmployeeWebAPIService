using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using EmployeeRepository;
using EmployeeRepository.Interface;

namespace EmployeeWebApi.DependencyInjection
{
    public class AutofacRegisterConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

             //builder.RegisterType<EmployeeWebApi>().AsSelf().InstancePerLifetimeScope();

            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeContext> ()
                   .As<IEmployeeContext>()
                   .InstancePerRequest();

            builder.RegisterType(typeof(EmployeeRepository.EmployeeRepository))
                     .As(typeof(EmployeeRepository.Interface.IEmployeeRepository))
                     .InstancePerRequest();

            builder.RegisterType<EmployeeCore.EmployeeManger>()
                   .As <EmployeeCore.Interface.IEmployeeManager>()
                   .InstancePerRequest();
           

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }


    }
}