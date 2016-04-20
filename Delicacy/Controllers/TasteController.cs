using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;

namespace Delicacy.Controllers
{
    public class TasteController : BaseController
    {
        public ContentResult GetAll()
        {
            TasteManager manager = new TasteManager();
            return Content(manager.GetList());
        }
	}
}