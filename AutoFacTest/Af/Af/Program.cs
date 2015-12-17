using Autofac;
using System;
using System.Reflection;

namespace Af
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //  builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterType<Log>().As<ILog>().InstancePerDependency().PropertiesAutowired().WithParameter("customMessage","Hello constructed!");
            builder.RegisterType<Context>().InstancePerDependency().PropertiesAutowired();
          
                

            IContainer Container = builder.Build();
            
            using (var scope = Container.BeginLifetimeScope())
            {
                var contexter = scope.Resolve<Context>();
                contexter.DataBase();
                 
             

            }
            Console.ReadLine();
        }
    }
}
