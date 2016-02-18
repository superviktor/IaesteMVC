using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iaeste.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConferencePhotos()
        {
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/Conference2016"))
                             .Select(fn => "~/Content/Images/Conference2016/" + Path.GetFileName(fn));
            return View();
        }

    }
}
