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
        public ActionResult Login(string userId,string pwd)
        {
            return Content(new AdminUserManager().Login(userId, pwd));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(string userId, string password)
        {
            return Content(new AdminUserManager().Add(userId,password));
        }

	}
}