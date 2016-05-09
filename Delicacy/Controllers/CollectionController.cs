using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;

namespace Delicacy.Controllers
{
    public class CollectionController : BaseController
    {
        /// <summary>
        /// 添加或取消收藏菜谱
        /// </summary>
        /// <param name="cookBookId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddOrCancleCookBook(string cookBookId)
        {
            if (!IsLogin())
                return Content(OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            return Content(new CollectionManager().Add(cookBookId, user.UserId));
        }
    }
}