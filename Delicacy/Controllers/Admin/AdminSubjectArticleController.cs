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
                return RedirectHome();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string content, string title, string brief)
        {
            if (!IsLogin())
                return RedirectHome();
            SubjectArticleManager articleManager = new SubjectArticleManager();
            return Content(articleManager.Add(content, adminUser.UserId, title, brief));
        }
        public ActionResult Manager(string pageindex)
        {
            if (!IsLogin())
                return RedirectHome();
            int pagesize = 10;//每页条数
            int pagecount;//总页数
            int pageIndex;
            CheckParameter.PageCheck(pageindex, out pageIndex);
            List<SubjectArticleTsfer> list = new SubjectArticleManager().GetPage(pageIndex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            return Content(new SubjectArticleManager().Delete(id));
        }

        public ActionResult Edit(string id)
        {
            if (!IsLogin())
                return RedirectHome();
            int iId;
            if(!int.TryParse(id,out iId))
                return RedirectHome();
             //ViewBag.Article = ;
            return View(new SubjectArticleManager().GetArticle(iId));
        }
        [ValidateInput(false)]
        public ActionResult Update(SubjectArticleTsfer article)
        {
            if (!IsLogin())
                return RedirectHome();
            return Content(new SubjectArticleManager().Update(article));
        }

        public ActionResult comments(string pageindex)
        {
            int pagesize = 10;
            int pagecount;
            List<CommentRecordTsfer> list = new CommentRecordManager().GetPage(2, pageindex, pagesize, out pagecount);
            ViewBag.pageIndex = pageindex;
            ViewBag.pageCount = pagecount;
            return View(list);
        }
        public ActionResult DeleteComment(string id)
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