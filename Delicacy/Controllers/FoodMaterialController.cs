using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;

namespace Delicacy.Controllers
{
    public class FoodMaterialController : BaseController
    {
        //
        // GET: /FoodMaterial/
        public ActionResult Index()
        {
            return View();
        }

        //public ContentResult GetList()
        //{
        //    FoodMaterialManager manager = new FoodMaterialManager();
        //   return Content(manager.GetList());
        //}
	}
}