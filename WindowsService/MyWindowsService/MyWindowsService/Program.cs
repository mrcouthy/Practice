using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //http://msdn.microsoft.com/en-us/library/zt39148a%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-18
            //install service 
            //installutil /i C:\Users\debug\xyz.dll
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new MyNewService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
