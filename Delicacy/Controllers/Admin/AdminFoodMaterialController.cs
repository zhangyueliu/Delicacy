using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;

namespace Delicacy.Controllers.Admin
{
    public class AdminFoodMaterialController : AdminBaseController
    {
        //
        // GET: /AdminFoodMaterial/
        public ActionResult Index(string pageindex)
        {
            if (!IsLogin())
                return RedirectHome();
            int pagesize = 10;
            int pagecount;
            List<FoodMaterialTsfer> list = new FoodMaterialManager().GetPage(pageindex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            return Content(new FoodMaterialManager().Delete(id));
        }
        public ActionResult Add(string name)
        {
            return Content(new FoodMaterialManager().Add(new FoodMaterialTsfer { Name = name,Priority=0 }));
        }
        public ActionResult Edit(string id, string name)
        {
            return Content(new FoodMaterialManager().Update(id, name));
        }
	}
}