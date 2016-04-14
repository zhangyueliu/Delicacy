using System;
using Tool;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Newtonsoft.Json;

namespace Delicacy.Controllers
{
    public class UploadController : BaseController
    {

        public ContentResult UploadImg()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                //var data = new { code = 200, successFileLength = 1 };
                //JsonConvert.SerializeObject(data);
                object uploadResult = UploadManager.UploadImg(files.Get("file"));
                return Content(JsonConvert.SerializeObject(uploadResult));//Content(UploadManager.UploadImg(files.Get("img")));
            }
            catch
            {
                return Content(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }

        public ActionResult UploadImgOne()
        {
            return View();
        }

        public ContentResult UploadImgTwo()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                string newImgName;
                if (UploadManager.UploadImg(files.Get("file"), out newImgName))
                    return Content("<input type='hidden' value='" + newImgName + "' id='upai_url'>");
                else
                    return Content("");//Content(UploadManager.UploadImg(files.Get("img")));
            }
            catch
            {
                return Content(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }
    }
}