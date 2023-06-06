using VIS.Models.Repositories;
using LightInject;
using VIS.Models;

namespace VIS.App_Start
{
    public class ServiceInstaller
    {
        public static void Install(IServiceContainer container)
        {
            //singletons
            container.RegisterSingleton<XmlManager>();

            //per request context
            container.SetDefaultLifetime<PerRequestLifeTime>();
            container.Register<IUnitOfWork, EFUnitOfWork>();
            

            container.RegisterControllers();
            container.EnableMvc();
        }

        public static T Get<T>()
        {
            return MvcApplication.IoCContainer.GetInstance<T>();
        }
    }
}