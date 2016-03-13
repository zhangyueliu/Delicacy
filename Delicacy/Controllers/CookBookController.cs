using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delicacy.Models;

namespace Delicacy.Controllers
{
    public class CookBookController : Controller
    {
        //
        // GET: /CookBook/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult PublishCookBook(CookBookModel model)
        {

            return Content("");
        }
	}
}