using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using SpaLNT.Data.Infrastructure;
using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories;
using SpaLNT.Models.Spa;
using SpaLNT.Services;
using System.Reflection;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(SpaLNT.Startup))]
namespace SpaLNT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var buidler = new ContainerBuilder();
            //Register all objects when Controllers instantiated
            buidler.RegisterControllers(Assembly.GetExecutingAssembly());

            buidler.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            buidler.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            buidler.RegisterType<SpaDbContext>().AsSelf().InstancePerRequest();

            //Repositories
            buidler.RegisterAssemblyTypes(typeof(BranchRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Services
            buidler.RegisterAssemblyTypes(typeof(BranchService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = buidler.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
