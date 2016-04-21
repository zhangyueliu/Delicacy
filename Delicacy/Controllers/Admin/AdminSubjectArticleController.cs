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
                return  RedirectIndex();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string content)
        {
            if (!IsLogin())
                return RedirectIndex();
            SubjectArticleManager articleManager = new SubjectArticleManager();
             return Content(articleManager.Add(content, adminUser.UserId));
        }
	}
}