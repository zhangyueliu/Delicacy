using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;
using DataTransfer;
namespace Delicacy.Controllers
{
    public class SubjectArticleController : BaseController
    {
        //
        // GET: /SubjectArticle/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPage(string pageIndex, string pageSize)
        {
           return Content(new SubjectArticleManager().GetPage(pageIndex, pageSize));
        }


        public ActionResult Get(string id)
        {
            int subjectArticleId;
            int.TryParse(id, out subjectArticleId);
            SubjectArticleTsfer s = (SubjectArticleTsfer)new SubjectArticleManager().Get(subjectArticleId).Data;
            return View(s);
        }
	}
}