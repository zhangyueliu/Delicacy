using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;

namespace Delicacy.Controllers
{
    /// <summary>
    /// 用户中心控制器
    /// </summary>
    public class UserCenterController : BaseController
    {
        //
        // GET: /UserCenter/
        [Authorize]
        public ActionResult Index()
        {
            if (!IsLogin())
                return Redirect("/");
            return View();
        }

        public ActionResult WaitCheck()
        {
            if (!IsLogin())
                return Redirect("/");
            return View();
        }

        public ActionResult WaitCheckDetail(string id)
        {
            if (!IsLogin())
                return Redirect("/");
            OutputModel model = new CookBookManager().GetCookBook(id);
            if (model.Data == null)
                return RedirectHome();
            return View(model.Data);
        }

        /// <summary>
        /// 获取待审核菜谱
        /// </summary>
        /// <returns></returns>
        public ActionResult GetaPageCookBookByStatus(string pageIndex, string pageSize, string status)
        {//这里没有分页
            if (user == null)
                return Content(OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            return Content(new CookBookManager().GetaPageCookBookByStatus(pageIndex, pageSize, user.UserId,status));
        }

        public ActionResult DeleteCookBook(string id)
        {
            return Content(new CookBookManager().Delete(id));
        }
        public ActionResult NotPass()
        {
            if (!IsLogin())
                return Redirect("/");
            return View();
        }
    }
        
    }
