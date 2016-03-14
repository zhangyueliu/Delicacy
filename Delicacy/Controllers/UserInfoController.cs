using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;
using Tool;
namespace Delicacy.Controllers
{
    public class UserInfoController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password">md5加密后的密码</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult Register(string loginId, string password)
        {
            UserInfoManager userManager = new UserInfoManager();
            return Content(userManager.Register(loginId, password));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password">MD5加密后的密码</param>
        /// <returns></returns>
       [HttpPost]
        public ContentResult Login(string loginId, string password)
        {
            UserInfoManager userManager = new UserInfoManager();
            return Content(userManager.Login(loginId, password));
        }
    }
}