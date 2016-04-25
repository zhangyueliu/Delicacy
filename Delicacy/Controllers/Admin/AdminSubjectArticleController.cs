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
    public class AdminSubjectArticleController : AdminBaseController
    {
        //
        // GET: /AdminSubjectArticle/
        public ActionResult Index()
        {
            if (!IsLogin())
                return  RedirectHome();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string content,string title,string brief)
        {
            if (!IsLogin())
                return RedirectHome();
            SubjectArticleManager articleManager = new SubjectArticleManager();
             return Content(articleManager.Add(content, adminUser.UserId,title,brief));
        }
        public ActionResult Manager()
        {
            if (!IsLogin())
                return RedirectHome();
            List<SubjectArticleTsfer> list = new SubjectArticleManager().GetList();
            return View(list);
        }
	}
}