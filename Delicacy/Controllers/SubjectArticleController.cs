using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;

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

        //public ActionResult GetPage(string pageIndex, string pageSize)
        //{

        //}


        public ActionResult Get(int subjectArticleId)
        {
            return Content(new SubjectArticleManager().Get(subjectArticleId));
        }
	}
}