using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Tool;

namespace Delicacy.Controllers
{
    public class CommentRecordController : BaseController
    {
        public ActionResult AddCookBookComment(string cookBookId,string pId,string content)
        {
            if (!IsLogin())
                return Content(OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            return Content(new CommentRecordManager().AddCookBookComment(cookBookId, content, pId, user.UserId));
        }

        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="cookBookId"></param>
        /// <returns></returns>
        public ActionResult GetComments(string cookBookId)
        {
            return Content(new CommentRecordManager().GetListCookBook(cookBookId));
        }
	}
}