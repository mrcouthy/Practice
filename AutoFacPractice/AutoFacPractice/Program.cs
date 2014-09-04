using Autofac;
using DemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacPractice
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();


            //builder.RegisterType<ConsoleOutputAndExtra>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            // builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
           // builder.Register(c => new ConfigReader("b")).As<IConfigReader>();
            Container = builder.Build();

            // The WriteDate method is where we'll make use
            // of our dependency injection. We'll define that
            // in a bit.
            WriteDate();
        }

        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
                var configReader = Container.Resolve<IConfigReader>(new NamedParameter("connfigSectionName", "b"));
               
                configReader.ConfigString();
            }
        }
    }
}
