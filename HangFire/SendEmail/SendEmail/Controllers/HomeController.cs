﻿using System.Linq;
using System.Web.Mvc;
using HangFire.Mailer.Models;
using Hangfire.Mailer.Models;
using Hangfire;
using System.Web.Hosting;
using System.IO;
using Postal;
using SendEmail;

namespace HangFire.Mailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly MailerDbContext _db = new MailerDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var comments = _db.Comments.OrderBy(x => x.Id).ToList();
            return View(comments);
        }

        [HttpPost]
        public ActionResult Create(Comment model)
        {
            if (ModelState.IsValid)
            {
                _db.Comments.Add(model);
                _db.SaveChanges();
                BackgroundJob.Enqueue(()=>NotifyNewComment(model.Id));
            }

            return RedirectToAction("Index");
        }

        [LogFailure]
        [AutomaticRetry(Attempts=2)]
        public static void NotifyNewComment(int commentId)
        {
            // Prepare Postal classes to work outside of ASP.NET request
            var viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            var engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            var emailService = new EmailService(engines);
            //--try breaking and see if hangfire retrites it
            //emailService = null;
            // Get comment and send a notification.
            using (var db = new MailerDbContext())
            {
                var comment = db.Comments.Find(commentId);

                var email = new NewCommentEmail
                {
                    To = "yourmail@example.com",
                    UserName = comment.UserName,
                    Comment = comment.Text
                };

                emailService.Send(email);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}