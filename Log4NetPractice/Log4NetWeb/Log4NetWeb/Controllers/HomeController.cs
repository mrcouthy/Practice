using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Logger.Error(ex);
            }
            
        }

    }
}
