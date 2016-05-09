using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool;
using DataTransfer;
using Manager;

namespace Delicacy.Controllers
{
    public class BaseController : Controller
    {
        protected ContentResult Content(OutputModel model)
        {
            return Content(JsonHelper.SerializeObject(model), "application/json", System.Text.Encoding.UTF8);
        }

        protected UserInfoTsfer user { get; set; }

        public BaseController()
        {
            user = System.Web.HttpContext.Current.Session["user"] as UserInfoTsfer;
            ViewBag.User = user;
            ViewBag.IsLogin = (user != null);
            FenleiList();
            ShicaiList();
        }
        /// <summary>
        /// 获取分类列表
        /// </summary>
        protected void FenleiList()
        {
            FoodSortManager manager = new FoodSortManager();
            OutputModel m = manager.GetList();
            if (m.StatusCode == 1)
            {
                ViewBag.listfenlei = (List<FoodSortTsfer>)m.Data;
            }
        }
        protected void ShicaiList()
        {
            FoodMaterialManager manager = new FoodMaterialManager();
            List<FoodMaterialTsfer> list = manager.GetList();

            if (list.Count > 0)
                ViewBag.listshicai = list;
        }


        /// <summary>
        /// 判断此用户是否登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected bool IsLogin()
        {
            return user != null;
        }

        /// <summary>
        /// 跳转到首页
        /// </summary>
        /// <returns></returns>
        protected ActionResult RedirectHome()
        {
            return Redirect("/Home/Index");
        }
    }
}
