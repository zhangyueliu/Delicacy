using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delicacy.Models;
using Manager;
using DataTransfer;
using Tool;

namespace Delicacy.Controllers
{
    public class CookBookController : BaseController
    {
        //
        // GET: /CookBook/
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult PublishCookBook(CookBookModel model)
        {
            if (user == null)
                return Content(OutputHelper.GetOutputResponse(ResultCode.NoLogin));
            CookBookManager manager = new CookBookManager();
            //这里可以用对象传入
            OutputModel outModel = manager.AddCookBook(user.UserId, model.Taste, model.FoodSort, model.Name, model.Description, model.Tips, model.FinalImg, model.ProcessImgDes, model.FoodMaterial, model.Status);

            return Content(outModel);
        }

        [HttpGet]
        public ActionResult  PublishCookBook()
        {
            //if (user == null)
            //    return Redirect("/Home/Index");
            return View();
        }
    }
}