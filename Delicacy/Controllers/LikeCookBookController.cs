using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;

namespace Delicacy.Controllers
{
    public class LikeCookBookController : BaseController
    {
        //
        // GET: /LikeCookBook/
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult GetList()
        {
            LikeCookBookManager manager = new LikeCookBookManager();
           return Content(manager.GetList());
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="cookBookId"></param>
        /// <returns></returns>
        public ActionResult Add(string cookBookId)
        {
            if (!IsLogin())
                return Content( OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            return Content(new LikeCookBookManager().Add(cookBookId, user.UserId));
        }
	}
}