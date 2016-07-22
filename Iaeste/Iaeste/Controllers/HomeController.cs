using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Iaeste.Models;



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

        [System.Web.Http.HttpGet]
        public ActionResult ConferencePhotos()
        {
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/Conference2016"))
                             .Select(fn => "~/Content/Images/Conference2016/" + Path.GetFileName(fn));
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult ConferencePhotos(HttpPostedFileBase file)
        {
            //TODO: create a system where filenames will start from 000 and bigger

            string fileName = Guid.NewGuid().ToString();
            string extencion = Path.GetExtension(file.FileName);
            fileName += extencion;
            List<string> extencions = new List<string>() { ".png", ".jpg", ".txt" };
            if (extencions.Contains(extencion))
            {
                file.SaveAs(Server.MapPath("/Content/Images/Conference2016/" + fileName));
                ViewBag.Message = "Saved";
            }
            else
            {
                ViewBag.Message = "Error";
            }

            return View("Index");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Offers()
        {
            var offersSet = Directory.EnumerateFiles(Server.MapPath("~/Content/PDFs/"))
                             .Select(fn => "~/Content/PDFs/" + Path.GetFileName(fn));
            return View(offersSet);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Offers(HttpPostedFileBase file)
        {
            //create a system of naming to locate file in the top of the page
            //how enter description ??
            string fileName = Guid.NewGuid().ToString();
            string extencion = Path.GetExtension(file.FileName);
            fileName += extencion;
            List<string> extencions = new List<string>() { ".pdf"};
            if (extencions.Contains(extencion))
            {
                file.SaveAs(Server.MapPath("/Content/PDFs/1" + fileName));
                ViewBag.Message = "Saved";
            }
            else
            {
                ViewBag.Message = "Error";
            }

            return RedirectToAction("Offers");
        }
        public ActionResult FAQ()
        {
            List<Question> list = new List<Question>();
            list.Add(new Question()
            {
                Id = 1,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ? ",
                Answer = " Sed vitae quam a libero efficitur vestibulum id at odio. Integer porttitor, elit et accumsan semper, risus"
            });
            list.Add(new Question()
            {
                Id = 2,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ? ",
                Answer = " Sed vitae quam a libero efficitur vestibulum id at odio. Integer porttitor, elit et accumsan semper, risus"
            });
            list.Add(new Question()
            {
                Id = 3,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ? ",
                Answer = " Sed vitae quam a libero efficitur vestibulum id at odio. Integer porttitor, elit et accumsan semper, risus"
            });
            list.Add(new Question()
            {
                Id = 4,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit ? ",
                Answer = " Sed vitae quam a libero efficitur vestibulum id at odio. Integer porttitor, elit et accumsan semper, risus"
            });

            return View(list);
        }
    }
}
