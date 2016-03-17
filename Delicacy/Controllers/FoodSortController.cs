using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;

namespace Delicacy.Controllers
{
    public class FoodSortController : BaseController
    {
        //
        // GET: /FoodSort/
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult GetList()
        {
            FoodSortManager manager = new FoodSortManager();
            return Content(manager.GetList());
        }
	}
}