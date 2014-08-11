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
            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Ram", Age = 20 });
            return Json(p,JsonRequestBehavior.AllowGet);
        }




        public ActionResult SetPerson(string username, string firstname, string lastname)
        {
            Person p = new Person { Name = username, Age = 1 };
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}