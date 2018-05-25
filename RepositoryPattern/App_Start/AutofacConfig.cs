using Autofac;
using Autofac.Integration.Mvc;
using Repository_Database;
using RepositoryPattern.Controllers;
using RepositoryPattern_RepoClasses;
using RepositoryPattern_RepoInterfaces;
using RepositoryPattern_ServiceClasses;
using RepositoryPattern_ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPattern.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>(); 
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerController>();
            builder.RegisterType<Northwind_DBEntities>().As<INorthwind_DBEntities>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}