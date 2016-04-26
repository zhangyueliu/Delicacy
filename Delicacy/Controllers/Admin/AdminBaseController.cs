using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTransfer;
using Tool;
namespace Delicacy.Controllers.Admin
{
    public class AdminBaseController : Controller
    {
        protected ContentResult Content(OutputModel model)
        {
            return Content(JsonHelper.SerializeObject(model), "application/json", System.Text.Encoding.UTF8);
        }

        protected AdminUserTsfer  adminUser { get; set; }

        public AdminBaseController()
        {
            adminUser = System.Web.HttpContext.Current.Session["adminUser"] as AdminUserTsfer;
            ViewBag.user = adminUser;
        }

        /// <summary>
        /// 判断此用户是否登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected bool IsLogin()
        {
            return adminUser != null;
        }

        protected ActionResult RedirectHome()
        {
            return Redirect("/AdminUser/Login");
        }
	}
}