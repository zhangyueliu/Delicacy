using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTransfer;
using Manager;
namespace Delicacy.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            CookBookManager manager = new CookBookManager();
            ViewBag.Hottest = manager.GetHottest(3);
            ViewBag.RecentCook = manager.GetRecent(3);
            ViewBag.RecentArticle = new SubjectArticleManager().GetRecent(4);
            return View();
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