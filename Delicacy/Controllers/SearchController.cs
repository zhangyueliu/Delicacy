using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;
using DataTransfer;

namespace Delicacy.Controllers
{
    public class SearchController : BaseController
    {
        /// <summary>
        /// 根据名称搜索菜谱
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult SearchCookBook(string name)
        {
            return Content(new CookBookManager().SearchByName(name));
        }
    }
}