using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Log4NetWeb.Systematic;

namespace Log4NetWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public void Index()
        {
            try
            {
                throw new Exception("Hi !");
            }
            catch (Exception ex)
            {
                Log4NetLogger l = new Log4NetLogger() ;
                l.Error(ex);
            }
            
        }

    }
}
