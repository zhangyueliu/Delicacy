using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;
using DataTransfer;
namespace Delicacy.Controllers.Admin
{
    public class AdminFoodSortController : AdminBaseController
    {
        //
        // GET: /AdminFoodSort/
        public ActionResult Index(string pageindex)
        {
            if (!IsLogin())
                return RedirectHome();
            int pagesize = 10;
            int pagecount;
            List<FoodSortTsfer> list = new FoodSortManager().GetPage(pageindex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            return Content(new FoodSortManager().Delete(id));
        }
        public ActionResult Add(string name)
        {
            return Content(new FoodSortManager().Add(new FoodSortTsfer { Name = name }));
        }
        public ActionResult Edit(string id,string name)
        {
           return Content(new FoodSortManager().Update(id, name));
        }
    }
}