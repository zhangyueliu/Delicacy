using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool;
using Manager;

namespace Delicacy.Controllers
{
    public class SupportScanRecordController : BaseController
    {
        [HttpPost]
        public ActionResult AddSupport(string cookBookId)
        {
            if (!IsLogin())
                return Content( OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            return Content(new SupportScanRecordManager().Add(cookBookId,user.UserId));
        }

	}
}