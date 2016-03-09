using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using DataTransfer;

namespace Delicacy.Controllers
{
    public class RegisterAndLoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /RegisterAndLogin/
        [HttpPost]
        public ActionResult Register(string loginId, string password)
        {
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                ViewData["msg"] = "邮箱或密码为空";
                return View();
            }
            UserInfoManager userManager = new UserInfoManager();
            OutputModel outmodel = userManager.Register(loginId, password);
            if (outmodel.StatusCode == 1)
            {
                ViewData["msg"] = "注册成功，请登录";
            }
            else
            {
                ViewData["msg"] = "注册失败";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string loginId, string password)
        {
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                ViewData["msg"] = "邮箱或密码为空";
                return View();
            }
            UserInfoManager userManager = new UserInfoManager();
            OutputModel outmodel = userManager.Login(loginId, password);
            if (outmodel.StatusCode == 1)
            {
                //登录成功跳转页面
                ViewData["msg"] = outmodel.Data;
            }
            else
            {
                ViewData["msg"] = outmodel.Data;
            }
            return View();
        }
    }
}