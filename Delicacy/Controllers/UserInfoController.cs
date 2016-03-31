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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult VerifyEmail(string guid)
        {
            VerifyRegisterManager verifyManager = new VerifyRegisterManager();
            if (verifyManager.VerifyEmail(guid))
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserCenter()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LostPwd()
        {
            return View();
        }
        [HttpPost]
        public ContentResult LostPwd(string loginId)
        {
            UserInfoManager userManager = new UserInfoManager();
            OutputModel o = userManager.LostPwd(loginId);
            if (o.StatusCode == 1)
            {
                Session["LostPwdLoginId"] = loginId;
            }
            return Content(o);
        }
        public ActionResult LostPwdVerifyEmail(string guid)
        {
            VerifyRegisterManager verifyManager = new VerifyRegisterManager();
            if (verifyManager.VerifyEmail(guid))
                return RedirectToAction("ResetPwd", "UserInfo");
            else
                return View("VerifyEmail");
        }
        [HttpGet]
        public ActionResult ResetPwd()
        {
            return View();
        }
        [HttpPost]
        public ContentResult ResetPwd(string loginId, string password)
        {
            UserInfoManager userManager = new UserInfoManager();
            UserInfoTsfer u = new UserInfoTsfer();
            var outputGet = userManager.Get(loginId);
            if (outputGet.StatusCode == 1)
            {
                u = (UserInfoTsfer)outputGet.Data;
                u.Password = password;
                return Content(userManager.Update(u));
            }
            return Content(outputGet);
        }
    }
}