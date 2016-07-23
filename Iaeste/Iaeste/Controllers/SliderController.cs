using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iaeste.Models;


namespace Iaeste.Controllers
{
    public class SliderController : Controller
    {
        public ActionResult Index()
        {
            using (IaesteContext db = new IaesteContext())
            {
                return View(db.gallery.ToList());
            }
        }

        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                //// You can skip this block, because it is only to force the user to upload specific resolution pics
                //System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);
                //if ((img.Width != 800) || (img.Height != 356))
                //{
                //    ModelState.AddModelError("", "Image resolution must be 800 x 356 pixels");
                //    return View();
                //}

                // Upload your pic
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/fol"), pic);
                ImagePath.SaveAs(path);
                using (IaesteContext db = new IaesteContext())
                {
                    Gallery gallery = new Gallery { ImagePath = "~/Content/fol/" + pic };
                    db.gallery.Add(gallery);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteImages()
        {
            using (IaesteContext db = new IaesteContext())
            {
                return View(db.gallery.ToList());
            }
        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImagesIDs)
        {
            using (IaesteContext db = new IaesteContext())
            {
                foreach (var id in ImagesIDs)
                {
                    var image = db.gallery.Single(s => s.ID == id);
                    string imgPath = Server.MapPath(image.ImagePath);
                    db.gallery.Remove(image);
                    if (System.IO.File.Exists(imgPath))
                        System.IO.File.Delete(imgPath);
                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");
        }
    }
}