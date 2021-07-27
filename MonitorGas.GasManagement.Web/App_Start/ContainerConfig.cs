using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using MonitorGas.GasManagement.Application.Interfaces;
using MonitorGas.GasManagement.Application.Services;
using MonitorGas.GasManagement.Data;
using MonitorGas.GasManagement.Web;
using MonitorGas.GasManagement.Web.Profiles;
using System.Web.Mvc;

namespace MonitorGas.GasManagement.App
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            ///Database instantiation
            builder.RegisterType<MonitorGasDbContext>().InstancePerRequest();

            ///Automapper Instantiation
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mappings>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IAsyncRepository<>))
                .InstancePerRequest();

            builder.RegisterType<GasSizeRepository>()
                    .As<IGasSizeRepository>()
                    .InstancePerRequest();

            builder.RegisterType<GasRepository>()
                    .As<IGasRepository>()
                    .InstancePerRequest();

            builder.RegisterType<OrderRepository>()
                    .As<IOrderRepository>()
                    .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}