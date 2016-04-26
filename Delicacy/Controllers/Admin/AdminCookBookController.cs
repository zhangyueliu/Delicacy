using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool;
using Manager;
using DataTransfer;
namespace Delicacy.Controllers.Admin
{
    public class AdminCookBookController : AdminBaseController
    {
        //
        // GET: /AdminCookBook/
        public ActionResult Index(string pageindex, string status)
        {
            if (!IsLogin())
                return RedirectHome();
            int pageSize = 5;
            int pageIndex;
            int pagecount;
            CheckParameter.PageCheck(pageindex, out pageIndex);
            List<CookBookTsfer> list = new CookBookManager().GetPage(pageIndex, pageSize, status, out pagecount);
            ViewBag.pageIndex = pageIndex;
            ViewBag.pageCount = pagecount;
            ViewBag.status = status;
            return View(list);
        }
        public ActionResult ShenHe(string ids,string status)
        {

            return Content(new CookBookManager().UpdateStaus( ids,status));
        }
    }
}