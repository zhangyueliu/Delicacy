using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;
using Tool;
namespace Delicacy.Controllers.Admin
{
    public class AdminCommentCookBookController : AdminBaseController
    {
        //
        // GET: /AdminCommentCookBook/
        public ActionResult Index(string pageindex)
        {
            int pagesize = 10;
            int pagecount;
            List<CommentRecordTsfer> list = new CommentRecordManager().GetPage(1,pageindex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            int i;
            if (!int.TryParse(id, out i))
            {
                return Content(new OutputModel { StatusCode = 3 });//3是错误参数
            }
            return Content(new CommentRecordManager().Delete(i));
        }
	}
}