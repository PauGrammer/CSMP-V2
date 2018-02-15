using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CSMP_V2.ViewModels;
using CSMP_V2.DataAccessLayer;

namespace CSMP_V2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var csmpDAL = new CSMPDAL();
            var home = new HomeViewModel();

            home.SNCList = csmpDAL.GetSNCList();
            if (!csmpDAL.ErrorHandler.IsSuccessful)
            {
                return new HttpNotFoundResult(csmpDAL.ErrorHandler.Message);
            }
            home.AreaList = csmpDAL.GetAreaList();
            if(!csmpDAL.ErrorHandler.IsSuccessful)
            {
                return new HttpNotFoundResult(csmpDAL.ErrorHandler.Message);
            }
            return View(home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}