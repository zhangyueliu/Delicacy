using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool;
namespace Delicacy.Controllers
{
    public class BaseController : Controller
    {
        protected ContentResult GetContentResult(OutputModel model)
        {
            return Content(JsonHelper.SerializeObject(model), "application/json", System.Text.Encoding.UTF8);
        }
	}
}