using Autofac;
using Autofac.Extras.DynamicProxy;
using BuildAppYD.Business.Concrete;
using BuildAppYD.Business.Service;
using BuildAppYD.Core.Utilities.Interceptors;
using BuildAppYD.DataAccess.Concrete.EntityFramework;
using BuildAppYD.DataAccess.Service;
using Castle.DynamicProxy;

namespace BuildAppYD.Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BuildingManager>().As<IBuildingService>();
            builder.RegisterType<EfBuildingDal>().As<IBuildingDal>();
            

            builder.RegisterType<RoomManager>().As<IRoomService>();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>();


            builder.RegisterType<StoreManager>().As<IStoreService>();
            builder.RegisterType<EfStoreDal>().As<IStoreDal>();




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
