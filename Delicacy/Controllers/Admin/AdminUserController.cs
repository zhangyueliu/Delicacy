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
    public class AdminUserController : AdminBaseController
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userId, string pwd)
        {
            return Content(new AdminUserManager().Login(userId, pwd));
        }
        public ActionResult LogOut()
        {
            Session["adminuser"] = null;
            return RedirectToAction("Login", "AdminUser");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(string userId, string password)
        {
            return Content(new AdminUserManager().Add(userId, password));
        }

        public ActionResult UserManager()
        {
            if (!IsLogin())
                return RedirectHome();
            return View(new UserInfoManager().GetAll());
        }
        public ActionResult Delete(string id)
        {
            return Content(new UserInfoManager().Delete(id));
        }
    }
}