using Simple.Repository;
using Simple.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple.Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            string constr = ConfigurationManager.ConnectionStrings["SimpleConnection"].ConnectionString;
            UsersRepository ur = new UsersRepository(constr);
            UsersService us = new UsersService(ur);
            return this.View(us.GetUsers());
        }
    }
}