using Autofac;
using Autofac.Integration.WebApi;
using EmployeeWebApi.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace EmployeeWebApi
{
    public static class DependencyWrapper
    {
        public static void Build()
        {
            //Configure AutoFac  
            AutofacRegisterConfig.Initialize(GlobalConfiguration.Configuration);

           
        }
    }
}