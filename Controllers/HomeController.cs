using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You successfully loaded the image.Use below options to continue.";

            return View();
        }

        public ActionResult Show() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Show(int? id) 
        {
            return RedirectToAction("Show","Home");
        }

        public ActionResult upload() 
        
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public virtual ActionResult upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/img"), pic);
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
            return RedirectToAction("Contact", "Home");
        }
    }
}