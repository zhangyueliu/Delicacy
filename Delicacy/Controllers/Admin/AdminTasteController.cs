using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;

namespace Delicacy.Controllers.Admin
{
    public class AdminTasteController : AdminBaseController
    {
        //
        // GET: /AdminTaste/
        public ActionResult Index(string pageindex)
        {
            if (!IsLogin())
                return RedirectHome();
            int pagesize = 10;
            int pagecount;
            List<TasteTsfer> list = new TasteManager().GetPage(pageindex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            return Content(new TasteManager().Delete(id));
        }
        public ActionResult Add(string name)
        {
            return Content(new TasteManager().Add(new TasteTsfer { Name = name ,Status=1}));
        }
        public ActionResult Edit(string id, string name)
        {
            return Content(new TasteManager().Update(id, name));
        }
	}
}