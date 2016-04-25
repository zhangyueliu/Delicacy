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
            ViewBag.IsSort = true;
            return View();
        }

        public ActionResult GetPageBySort(string sortId,string pageIndex,string pageSize)
        {
            return Content(new CookBookManager().GetCookBookBySort(sortId,pageIndex,pageSize));
        }


        public ActionResult ListShiCai(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectHome();
            //int i = int.Parse(id);
            //CookBookManager manager = new CookBookManager();
            //FoodMaterial_CookBookTsferManager fmcbmanager = new FoodMaterial_CookBookTsferManager();
            //FoodMaterialManager fmmanager = new FoodMaterialManager();
            //FoodMaterialTsfer f = fmmanager.Get(i);
            //if (f != null)
            //{
            //    ViewBag.sort = f.Name;
            //}
            //List<FoodMaterial_CookBookTsfer> list = fmcbmanager.GetListByFoodMaterialId(i);
            //List<string> strs = new List<string>();
            //foreach (FoodMaterial_CookBookTsfer item in list)
            //{
            //    strs.Add(item.CookBookId);
            //}
            //OutputModel o = manager.GetListByIds(strs);
            //if (o.StatusCode == 1)
            //    ViewBag.cookbookList = (List<CookBookTsfer>)o.Data;

            ViewBag.IsSort = false;
            return View("List");
        }
        public ActionResult Get(string cookBookId)
        {
            if (string.IsNullOrEmpty(cookBookId))
                return RedirectHome();
            return Content(new CookBookManager().GetCookBook(cookBookId));
        }

        public ActionResult GetPageByFoodMaterial(string foodMaterialId,string pageIndex,string pageSize)
        {
            return Content(new CookBookManager().GetPageByFoodMaterial(foodMaterialId, pageIndex, pageSize));
        }
    }
}