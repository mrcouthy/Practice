using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class AjaxGetPostController:Controller
    {
        public ActionResult GetPost()
        {
            return View();
        }

        public string TellMeDate()
        {
            return DateTime.Today.ToString();
        }
    }
}