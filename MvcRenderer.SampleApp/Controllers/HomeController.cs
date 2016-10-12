﻿namespace MvcRenderer.SampleApp.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GoToWebForms()
        {
            this.TempData["Message"] = "Hello from MVC !";
            this.TempData["Time"] = DateTime.UtcNow;
            return Redirect("~/CustomPage.aspx");
        }

        [ChildActionOnly]
        public ActionResult IntegratedZone()
        {
            return PartialView();
        }
    }
}