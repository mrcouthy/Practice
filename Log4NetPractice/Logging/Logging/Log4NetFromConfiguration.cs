using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Log4NetFromConfiguration
    {
        public static void Test()
        {
            ILog Log = LogManager.GetLogger("test");
            XmlConfigurator.Configure(); //only once
            Log.Debug("Application is starting");
            Console.WriteLine("Test Line");
            Log.Debug("Application is ending");
            Console.Read();
        }
    }
}
