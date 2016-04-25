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
            OutputModel outModel = manager.AddCookBook(user.UserId, model.Taste, model.FoodSort, model.Name, model.Description, model.Tips, model.FinalImg, model.ProcessImgDes, model.MainMaterial, model.Status, model.AssistMaterial, model.FoodMaterial);

            return Content(outModel);
        }

        [HttpGet]
        public ActionResult PublishCookBook()
        {
            if (!IsLogin())
                return Redirect("/");
            ViewBag.FoodMaterial = new FoodMaterialManager().GetList();
            return View();
        }
        public ActionResult List(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectHome();

            ViewBag.sort = new FoodSortManager().Get(id);
            ViewBag.IsSort = true;
            return View();
        }

        public ActionResult GetPageBySort(string sortId, string pageIndex, string pageSize)
        {
            return Content(new CookBookManager().GetCookBookBySort(sortId, pageIndex, pageSize));
        }

        public ActionResult GetPageByFoodMaterial(string foodMaterialId, string pageIndex, string pageSize)
        {
            return Content(new CookBookManager().GetPageByFoodMaterial(foodMaterialId, pageIndex, pageSize));
        }


        public ActionResult ListShiCai(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectHome();
            ViewBag.sort = new FoodMaterialManager().Get(id).Name;
            ViewBag.IsSort = false;
            return View("List");
        }
        /// <summary>
        /// 显示菜谱详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowDetail(string cookBookId, string isSort)
        {
            if (isSort == "href")
                ViewBag.IsSort = true;
            else
                ViewBag.IsSort = false;
            OutputModel model = new CookBookManager().GetCookBook(cookBookId);
            return View(model.Data);
        }
    }
}