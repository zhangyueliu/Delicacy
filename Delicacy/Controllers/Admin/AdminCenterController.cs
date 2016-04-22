using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delicacy.Controllers.Admin
{
    public class AdminCenterController : AdminBaseController
    {
        //
        // GET: /AdminCenter/
        public ActionResult Index()
        {
            if (!IsLogin())
                return RedirectIndex();
            return View();
        }


	}
}