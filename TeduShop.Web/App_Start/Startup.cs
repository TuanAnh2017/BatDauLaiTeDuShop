using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using TeduShop.Data.Infrastructure;
using TeduShop.Data;
using TeduShop.Data.Repositories;
using TeduShop.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(TeduShop.Web.App_Start.Startup))]
// cái này nó sẽ báo cho trình biên dịch biết nó nó chạy Auto StartUp khi mà ứng dụng này đc chạy

namespace TeduShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) // Cái đối tượng AppBuilder này nó sẽ cho phép khởi tạo các vấn đề khi
                                                   //Chúng ta chạy ứng dụng
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            Configautofac(app);
        }

        private void Configautofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Register your Web APi Controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<TeduShopDbContext>().AsSelf().InstancePerRequest();

            //Repository
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Sau khi khởi tạo, nó sẽ gán tất cả vào 1 cái thùng chứa
            Autofac.IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //=> Nó thay thế cơ chế mặc định = cơ chế chúng ta đã Register

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            // Set cho API cái GlobalConfig, DependencyResolver ta cũng gắn container cho nó vào
            // Cả API lẫn Controller đều có thể sử dụng chung
        }
    }
}
