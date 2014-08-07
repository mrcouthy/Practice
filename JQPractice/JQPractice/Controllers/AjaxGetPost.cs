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

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public ActionResult GetPerson()
        {
            return Json(new Person { Name = "Ram", Age = 20 },JsonRequestBehavior.AllowGet);
        }
    }
}