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
            UserInfoTsfer user;
            if (!IsLogin(out user))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult PublishCookBook(CookBookModel model)
        {
            UserInfoTsfer user;
            if(!IsLogin(out user))
                return RedirectToAction("Index","Home");
            CookBookManager manager = new CookBookManager();
        OutputModel outModel=manager.AddCookBook(user.UserId,model.Taste, model.FoodSort, model.Name, model.Description, model.Tips, model.FinalImg, model.ProcessImgDes, model.FoodMaterial, model.Status);
        return Content(outModel);
        }
	}
}