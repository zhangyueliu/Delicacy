using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;

namespace Delicacy.Controllers
{
    public class LikeCookBookController : BaseController
    {
        //
        // GET: /LikeCookBook/
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult GetList()
        {
            LikeCookBookManager manager = new LikeCookBookManager();
           return Content(manager.GetList());
        }
	}
}