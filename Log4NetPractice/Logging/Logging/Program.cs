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
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(); //only once
            Log.Debug("Application is starting");
            Console.WriteLine("Test Line");
            var testClass = new TestClass();
            testClass.LogSomething();
            Log.Debug("Application is ending");
            Console.Read();
        }
    }

    public class TestClass
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void LogSomething()
        {
            for (int i = 0; i < 100; i++)
            {
                Log.InfoFormat("CurrentTime is [{0}]", DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss~fff"));
            }
        }
    }
}
