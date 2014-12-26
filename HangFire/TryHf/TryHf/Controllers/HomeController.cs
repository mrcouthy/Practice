using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TryHf.Controllers
{
    public class HomeController : Controller
    {
        //http://docs.hangfire.io/en/latest/tutorials/highlight.html
        public string Index()
        {
            return "Hello";
        }
    }
}
