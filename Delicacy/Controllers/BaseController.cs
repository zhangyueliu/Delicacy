using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool;
using DataTransfer;

namespace Delicacy.Controllers
{
    public class BaseController : Controller
    {
        protected ContentResult Content(OutputModel model)
        {
            return Content(JsonHelper.SerializeObject(model), "application/json", System.Text.Encoding.UTF8);
        }

        protected UserInfoTsfer user{get;set;}

        public BaseController()
        {
            IsLogin();

        }

        /// <summary>
        /// 判断此用户是否登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected bool IsLogin()
        {
            user = System.Web.HttpContext.Current.Session["user"] as UserInfoTsfer;
            ViewBag.User = user;
            ViewBag.IsLogin = (user != null);
            return ViewBag.IsLogin = (user != null);
            //return true;
        }
	}
}